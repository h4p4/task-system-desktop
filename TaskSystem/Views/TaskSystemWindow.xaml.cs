using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaskSystem.Models;
using TaskSystem.ViewModels;

namespace TaskSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskSystemWindow.xaml
    /// </summary>
    public partial class TaskSystemWindow : Window
    {
        private TaskSystemWindow currentWindow;

        //private bool _canEditPanelClose = true; // Отвечает за то, может ли панель редактирования быть свернутой
        private int _animationFramesCount = 64; // количество кадров анимации
        private int _tabAnimationSpeed = 2; // скорость анимации (по умолчанию) где 1 - медленно, 2 - быстрее, 4, 8, 16, 32 - самая быстрая анимация, 64 - нет анимации
        User? _currentUser = Helper.currentUser;
        static string _title;
        public TaskSystemWindow()
        {

            InitializeComponent();
            currentWindow = Application.Current.Windows.OfType<TaskSystemWindow>().First();

            _title = Title;
            //Title = Title + " - " + _currentUser.Surname +
            //    " " + _currentUser.FirstName +
            //    " " + _currentUser.MiddleName +
            //    " - " + DateTime.Now.Date.ToString("D");
            Helper.taskSystemContext.Users.Load();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += Timer_Tick;
            LiveTime.Start();
            

            DispatcherTimer FontLiveTime = new DispatcherTimer();
            FontLiveTime.Interval = TimeSpan.FromMilliseconds(250);
            FontLiveTime.Tick += FontControlTimer_Tick;
            FontLiveTime.Start();
            //Binding binding = new Binding();
            //binding.Source = this;
            //binding.Path = new PropertyPath("TBlockWidth");
            //binding.Mode = BindingMode.TwoWay;
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //ChangeFontSize();
        }
        private void FontControlTimer_Tick(object sender, EventArgs e)
        {
            ChangeFontSize();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //TaskAddDateCurrentDateLabel.Content = DateTime.Now.ToString("HH:mm:ss");
            if (_currentUser != null)
            {
                Title = _title + " - " + _currentUser.Surname +
                    " " + _currentUser.FirstName +
                    " " + _currentUser.MiddleName +
                    " - " + DateTime.Now.Date.ToString("D") + " - " + DateTime.Now.AddMilliseconds(500).ToString("HH:mm:ss");
            }
        }
        private void AcceptTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
                dep = VisualTreeHelper.GetParent(dep);
            int index = TaskListAvailable.ItemContainerGenerator.IndexFromContainer(dep);
            TaskListAvailable.SelectedIndex = index;
        }
        private void ShowRightTabBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenTab();
            CloseTab();
            AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);

        }
        private void FilterTaskCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilterByUserLoginTBox.Visibility = Visibility.Hidden;
            FilterByUserLoginTBox.Text = String.Empty;
            if (FilterTaskCBox.SelectedIndex == 2)
                FilterByUserLoginTBox.Visibility = Visibility.Visible;
            System.Threading.Tasks.Task.Delay(50);
            ChangeFontSize();
        }
        private void ChangeTaskStatusCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DependencyObject dep = (DependencyObject)e.OriginalSource;
            //while ((dep != null) && !(dep is ListViewItem))
            //    dep = VisualTreeHelper.GetParent(dep);
            //int index = TaskList.ItemContainerGenerator.IndexFromContainer(dep);
            //TaskList.SelectedIndex = index;
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e) // ПЕРЕНЕСТИ ВО ViewModel!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            //Helper.currentUser = _currentUser = null;
            //Application.Current.Windows[0].Show();
            ////LoginWindow loginWindow = new LoginWindow();
            //this.Close();
            //loginWindow.Show();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e) // тоже по-хорошему во ViewModel
        {
            Application.Current.Shutdown(); 
        }
        private async void AllUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TasksOfSelectedUserDGrid.Visibility == Visibility.Visible) // заходит сюда если вкладка тасков выбранного юзера открыта
            {
                ShowTasksUserAccept.IsEnabled = true;
                ShowTasksUserMade.IsEnabled = true;
                //TopRowShowAllUsers.Height = new GridLength(20, GridUnitType.Star);
                //BottomRowShowUsersTasks.Height = new GridLength(0, GridUnitType.Star);
                // здесь уменьшать нижний row
                HideBottomRowUsersTasks();
                //TasksOfSelectedUserDGrid.Visibility = Visibility.Hidden;
                UsersDGrid.Visibility = Visibility.Visible;
                ShowAllUserBorder.Visibility = Visibility.Visible;
                ShowTasksUserAccept.Visibility = Visibility.Visible;
                ShowTasksUserMade.Visibility = Visibility.Visible;

                //TasksTabControl.Visibility = Visibility.Hidden;
                AllUsersBtn.Content = "Back";
                return;
            }

            if (UsersDGrid.Visibility == Visibility.Hidden) // заходит сюда если датагрид со всеми юзерами спрятан и делает его видимым
            {
                // здесь уве
                //TopRowShowAllUsers.Height = new GridLength(20, GridUnitType.Star);
                //BottomRowShowUsersTasks.Height = new GridLength(0, GridUnitType.Star);

                UsersDGrid.Visibility = Visibility.Visible;
                ShowAllUserBorder.Visibility = Visibility.Visible;
                ShowTasksUserAccept.Visibility = Visibility.Visible;
                ShowTasksUserMade.Visibility = Visibility.Visible;

                LeftTabOpen();
                await System.Threading.Tasks.Task.Delay(1);
                LeftGrid.Width = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;
                //TasksTabControl.Visibility = Visibility.Hidden;
                AllUsersBtn.Content = "Back";
                return;
            }

            // по умолчанию
            AllUsersBtn.Content = "Show all users";
            //UsersDGrid.SelectedItem = null;
            TasksTabControl.Visibility = Visibility.Visible;
            LeftTabClose();
            await System.Threading.Tasks.Task.Delay(400);

            //UsersDGrid.Visibility = Visibility.Hidden;
            ShowAllUserBorder.Visibility = Visibility.Hidden;
            ShowTasksUserAccept.Visibility = Visibility.Hidden;
            ShowTasksUserMade.Visibility = Visibility.Hidden;

        }

        private async void LeftTabClose()
        {
            var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;
            //if (AllUsersGridLeftColumn.Width.ToString() == "0*")
            //{
            for (int currentFrame = _animationFramesCount; currentFrame > 0; currentFrame -= _tabAnimationSpeed)
            {
                //LeftGrid.Width = new GridLength(GlobalGridLeftColumnsActualWidth / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                LeftGrid.Width = GlobalGridLeftColumnsActualWidth / _animationFramesCount * currentFrame;
                ShowRightTabBtn.IsEnabled = false;
                AllUsersBtn.IsEnabled = false;

                await System.Threading.Tasks.Task.Delay(1);
            }
            LeftGrid.Width = GlobalGridLeftColumnsActualWidth;
            UsersDGrid.Visibility = Visibility.Hidden;
            await System.Threading.Tasks.Task.Delay(50);
            AllUsersBtn.IsEnabled = true;
            ShowRightTabBtn.IsEnabled = true;
            //AllUsersGridRightColumn.Width = new GridLength(GlobalGridLeftColumnsActualWidth, GridUnitType.Pixel);
            //}
        }

        private async void LeftTabOpen()
        {
            var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;
            //if (AllUsersGridLeftColumn.Width.ToString() == "0*")
            //{
            for (int currentFrame = 0; currentFrame < _animationFramesCount; currentFrame += _tabAnimationSpeed)
            {
                //LeftGrid.Width = new GridLength(GlobalGridLeftColumnsActualWidth / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                LeftGrid.Width = GlobalGridLeftColumnsActualWidth / _animationFramesCount * currentFrame;
                ShowRightTabBtn.IsEnabled = false;
                AllUsersBtn.IsEnabled = false;


                await System.Threading.Tasks.Task.Delay(1);
            }
            LeftGrid.Width = GlobalGridLeftColumnsActualWidth;
            await System.Threading.Tasks.Task.Delay(50);
            ShowRightTabBtn.IsEnabled = true;
            AllUsersBtn.IsEnabled = true;




            //AllUsersGridRightColumn.Width = new GridLength(GlobalGridLeftColumnsActualWidth, GridUnitType.Pixel);
            //}
        }

        private void myTasksTab_Selected(object sender, RoutedEventArgs e)
        {
            ChangeFontSize();
            FilterTaskCBox.Visibility = Visibility.Hidden;
            TaskCBox.Visibility = Visibility.Visible;
            TaskCBox.SelectedIndex = 0;
        }
        private void availableTasksTab_Selected(object sender, RoutedEventArgs e)
        {
            ChangeFontSize();
            TaskCBox.Visibility = Visibility.Hidden;
            FilterTaskCBox.Visibility = Visibility.Visible;
            FilterTaskCBox.SelectedIndex = 0;
        }
        private void availableTasksTab_Unselected(object sender, RoutedEventArgs e)
        {
            FilterByUserLoginTBox.Visibility = Visibility.Hidden;
        }
        private async void OpenTab()
        {
            var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;

            bool willMakeWindowWider = (currentWindow.Width < 1050);
            if (GlobalGridRightColumn.Width.ToString() == "0*")
            {
                for (int currentFrame = 0; currentFrame < _animationFramesCount; currentFrame += _tabAnimationSpeed)
                {
                    GlobalGridRightColumn.Width = new GridLength(5.12 / _animationFramesCount * currentFrame, GridUnitType.Star);
                    AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);
                    //if leftGrid visible
                    LeftGrid.Width -= GlobalGridRightColumn.ActualWidth / (_animationFramesCount * currentFrame);
                    AllUsersBtn.IsEnabled = false;
                    ShowRightTabBtn.IsEnabled = false;


                    if (willMakeWindowWider)
                        currentWindow.MinWidth += GlobalGridRightColumn.Width.Value * (_tabAnimationSpeed * 1.5);
                    await System.Threading.Tasks.Task.Delay(1);
                }
                currentWindow.MinWidth = 1050;
                GlobalGridRightColumn.Width = new GridLength(5.12, GridUnitType.Star);
                await System.Threading.Tasks.Task.Delay(50);
                ShowRightTabBtn.IsEnabled = true;
                AllUsersBtn.IsEnabled = true;
                // здесь

                AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);
                ShowRightTabBtn.Content = "Hide my profile";
            }

        }
        private async void CloseTab()
        {
            //var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;

            currentWindow.MinWidth = 800;
            if (GlobalGridRightColumn.Width.ToString() == "5.12*")
            {
                for (int currentFrame = _animationFramesCount; currentFrame > 0; currentFrame -= _tabAnimationSpeed)
                {
                    GlobalGridRightColumn.Width = new GridLength(5.12 / _animationFramesCount * currentFrame, GridUnitType.Star);
                    AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);
                    // if left grid visible
                    //LeftGrid.Width += GlobalGridRightColumn.ActualWidth / (_animationFramesCount * currentFrame);
                    AllUsersBtn.IsEnabled = false;
                    ShowRightTabBtn.IsEnabled = false;
                    var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;
                    LeftGrid.Width = GlobalGridLeftColumnsActualWidth;

                    await System.Threading.Tasks.Task.Delay(1);
                }
                GlobalGridRightColumn.Width = new GridLength(0, GridUnitType.Star);
                await System.Threading.Tasks.Task.Delay(50);
                ShowRightTabBtn.IsEnabled = true;
                AllUsersBtn.IsEnabled = true;
                var GlobalGridLeftColumnsActualWidth_ = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;

                LeftGrid.Width = GlobalGridLeftColumnsActualWidth_;
                AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);
                ShowRightTabBtn.Content = "Show my profile";
            }

        }

        private void FilterByUserLoginTBox_LostFocus(object sender, RoutedEventArgs e)
        {

        } // не готово

        private void FilterByUserLoginTBox_GotFocus(object sender, RoutedEventArgs e)
        {

        } // не готово

        private void ShowTasksUserAccept_Click(object sender, RoutedEventArgs e)
        {
            ShowTasksUserAccept.IsEnabled = false;
            ShowTasksUserMade.IsEnabled = true;
            TasksOfSelectedUserDGrid.Visibility = Visibility.Visible;
            AllUsersBtn.Content = "Back";
            //TopRowShowAllUsers.Height = new GridLength(10, GridUnitType.Star);
            //BottomRowShowUsersTasks.Height = new GridLength(10, GridUnitType.Star);
            ShowBottomRowUsersTasks();

        }

        private void ShowTasksUserMade_Click(object sender, RoutedEventArgs e)
        {
            ShowTasksUserAccept.IsEnabled = true;
            ShowTasksUserMade.IsEnabled = false;
            TasksOfSelectedUserDGrid.Visibility = Visibility.Visible;
            AllUsersBtn.Content = "Back";
            //TopRowShowAllUsers.Height = new GridLength(10, GridUnitType.Star);
            //BottomRowShowUsersTasks.Height = new GridLength(10, GridUnitType.Star);
            ShowBottomRowUsersTasks();
        }
        private async void ShowBottomRowUsersTasks()
        {
            if (TopRowShowAllUsers.Height.ToString() == "20*")
            {
                TopRowShowAllUsers.Height = new GridLength(10, GridUnitType.Star);
                for (int currentFrame = 0; currentFrame < _animationFramesCount; currentFrame += _tabAnimationSpeed)
                {
                    BottomRowShowUsersTasks.Height = new GridLength(9.99 / _animationFramesCount * currentFrame, GridUnitType.Star);

                    //TopRowShowAllUsers.Height = new GridLength(10 / _animationFramesCount * currentFrame, GridUnitType.Star);
                    await System.Threading.Tasks.Task.Delay(1);
                }
                BottomRowShowUsersTasks.Height = new GridLength(10, GridUnitType.Star);
            }
        }
        private async void HideBottomRowUsersTasks()
        {
            if (TopRowShowAllUsers.Height.ToString() == "10*")
            {
                TopRowShowAllUsers.Height = new GridLength(20, GridUnitType.Star);

                for (int currentFrame = _animationFramesCount; currentFrame > 0; currentFrame -= _tabAnimationSpeed)
                {
                    BottomRowShowUsersTasks.Height = new GridLength(9.99 / _animationFramesCount * currentFrame * 1.89, GridUnitType.Star);

                    //TopRowShowAllUsers.Height = new GridLength(/*20*/ / _animationFramesCount * currentFrameTop, GridUnitType.Star);
                    await System.Threading.Tasks.Task.Delay(1);
                }
                //TopRowShowAllUsers.Height = new GridLength(20, GridUnitType.Star);
                BottomRowShowUsersTasks.Height = new GridLength(0, GridUnitType.Star);
                TasksOfSelectedUserDGrid.Visibility = Visibility.Hidden;

            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            AllUsersGridRightColumn.Width = new GridLength(GlobalGridRightColumn.ActualWidth, GridUnitType.Pixel);

            // if visible
            var GlobalGridLeftColumnsActualWidth = firt.ActualWidth + secd.ActualWidth + thrd.ActualWidth + frth.ActualWidth + ffth.ActualWidth;
            LeftGrid.Width = GlobalGridLeftColumnsActualWidth;
            ChangeFontSize();

        }
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
        private void ChangeTBlockWidth(string tBlockName, double newTBlockWidth)
        {
            foreach (var textBlock in FindVisualChildren<TextBlock>(this))
            {
                if (textBlock.Name == tBlockName)
                {
                    textBlock.Width = newTBlockWidth;
                }
            }
        }
        private void ChangeFontSize()
        {

            if (currentWindow.WindowState == WindowState.Maximized)
            {
                ChangeTBlockWidth("TaskAvailableTitleTBlock", 170);
                ChangeTBlockWidth("TaskAcceptedTitleTBlock", 170);
                ChangeTBlockWidth("TaskAvailableDescTBlock", 370);
                ChangeTBlockWidth("TaskAcceptedDescTBlock", 370);
                //DescWidth = 270;
                currentWindow.FontSize = 18; return;
            }
            //TaskAv
            //TaskAvailableDescTBlockColumn. = 200;
            ChangeTBlockWidth("TaskAvailableTitleTBlock", 70);
            ChangeTBlockWidth("TaskAcceptedTitleTBlock", 70);
            ChangeTBlockWidth("TaskAvailableDescTBlock", 200);
            ChangeTBlockWidth("TaskAcceptedDescTBlock", 200);
            FontSize = 13;
            if (currentWindow.Width > 1900)
            {
                ChangeTBlockWidth("TaskAvailableTitleTBlock", 150);
                ChangeTBlockWidth("TaskAcceptedTitleTBlock", 150);
                ChangeTBlockWidth("TaskAvailableDescTBlock", 320);
                ChangeTBlockWidth("TaskAcceptedDescTBlock", 320);

                //DescWidth = 240;
                currentWindow.FontSize = 17; return;
            }
            if (currentWindow.Width > 1700)
            {
                ChangeTBlockWidth("TaskAvailableTitleTBlock", 130);
                ChangeTBlockWidth("TaskAcceptedTitleTBlock", 130);
                ChangeTBlockWidth("TaskAvailableDescTBlock", 300);
                ChangeTBlockWidth("TaskAcceptedDescTBlock", 300);

                //DescWidth = 230;
                currentWindow.FontSize = 16; return;
            }
            if (currentWindow.Width > 1500)
            {
                ChangeTBlockWidth("TaskAvailableTitleTBlock", 110);
                ChangeTBlockWidth("TaskAcceptedTitleTBlock", 110);
                ChangeTBlockWidth("TaskAvailableDescTBlock", 280);
                ChangeTBlockWidth("TaskAcceptedDescTBlock", 280);

                //DescWidth = 220;
                currentWindow.FontSize = 15; return;
            }
            if (currentWindow.Width > 1300)
            {
                ChangeTBlockWidth("TaskAvailableTitleTBlock", 90);
                ChangeTBlockWidth("TaskAcceptedTitleTBlock", 90);
                ChangeTBlockWidth("TaskAvailableDescTBlock", 260);
                ChangeTBlockWidth("TaskAcceptedDescTBlock", 260);

                //DescWidth = 210;
                currentWindow.FontSize = 14; return;
            }
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            //NewTaskTitleTBox.Text = String.Empty;
            //NewTaskDescTBox.Text = String.Empty;
            BottomRowChangeVisability();
        }
        private void CancelAddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            NewTaskTitleTBox.Text = String.Empty;
            NewTaskDescTBox.Text = String.Empty;
            //TaskAddTitle.Text = String.Empty;
            //TaskAddDescription.Text = String.Empty;
            BottomRowChangeVisability();
        }
        private async void BottomRowChangeVisability()
        {
            if (AddTaskBtn.Content != "Save task")
            {
                AddTaskBtn.Content = "Save task";
                for (int currentFrame = 1; currentFrame < _animationFramesCount; currentFrame += _tabAnimationSpeed)
                {
                    CancelAddTaskBtn.Visibility = Visibility.Hidden;
                    AddTaskBtn.Visibility = Visibility.Hidden;
                    NewTaskInformationGrid.Visibility = Visibility.Hidden;
                    BottomRow.Height = new GridLength(200 / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                    BottomRowLastRow.Height = new GridLength(200 / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                    await System.Threading.Tasks.Task.Delay(1);
                }
                BottomRow.Height = new GridLength(200, GridUnitType.Pixel);
                BottomRowLastRow.Height = new GridLength(200, GridUnitType.Pixel);
                AddTaskBtn.Visibility = Visibility.Visible;
                CancelAddTaskBtn.Visibility = Visibility.Visible;
                NewTaskInformationGrid.Visibility = Visibility.Visible;

                AddTaskBtn.VerticalAlignment = VerticalAlignment.Bottom;
                CancelAddTaskBtn.VerticalAlignment = VerticalAlignment.Bottom;
                return;
            }
            AddTaskBtn.Content = "Add task";
            AddTaskBtn.VerticalAlignment = VerticalAlignment.Center;
            CancelAddTaskBtn.VerticalAlignment = VerticalAlignment.Center;
            for (int currentFrame = _animationFramesCount; currentFrame > 1; currentFrame -= _tabAnimationSpeed)
            {
                CancelAddTaskBtn.Visibility = Visibility.Hidden;
                AddTaskBtn.Visibility = Visibility.Hidden;
                NewTaskInformationGrid.Visibility = Visibility.Hidden;
                BottomRow.Height = new GridLength(200 / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                BottomRowLastRow.Height = new GridLength(200 / _animationFramesCount * currentFrame, GridUnitType.Pixel);
                await System.Threading.Tasks.Task.Delay(1);
            }
            AddTaskBtn.Visibility = Visibility.Visible;
            BottomRow.Height = new GridLength(40, GridUnitType.Pixel);
            BottomRowLastRow.Height = new GridLength(40, GridUnitType.Pixel);
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            ChangeFontSize();
        }


        private void TaskCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Threading.Tasks.Task.Delay(50);
            ChangeFontSize();
        }
    }
}

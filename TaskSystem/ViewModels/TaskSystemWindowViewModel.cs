using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using TaskSystem;
using TaskSystem.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using TaskSystem.Views;

namespace TaskSystem.ViewModels
{
    public class TaskSystemWindowViewModel : INotifyPropertyChanged
    {

        private Models.Task _selectedTask;

        private ComboBoxItem _taskComboBoxSelectedItem;
        private ComboBoxItem _filterTaskCBoxSelectedItem;
        private ComboBoxItem _taskStatusesSelectedItem;

        private string _filterByUserText;

        private RelayCommand _taskCBoxSelectionChangedCommand;
        private RelayCommand _filterTaskCBoxSelectionChangedCommand;
        private RelayCommand _taskStatusCBoxSelectionChangedCommand;
        private RelayCommand _acceptTaskClickedCommand;

        private ObservableCollection<Models.Task> _tasksAccepted;
        private ObservableCollection<Models.Task> _tasksAvailable;

        private ObservableCollection<ComboBoxItem> _taskComboBoxItems;
       
        public string FilterByUserText
        {
            get { return _filterByUserText; }
            set 
            {
                _filterByUserText = value; 
                OnPropertyChanged(nameof(FilterByUserText));
                FilterTaskCBoxSelectionChanged(FilterByUserText);
            }
        }
        
        public ComboBoxItem TaskComboBoxSelectedItem
        {
            get { return _taskComboBoxSelectedItem; }
            set
            {
                _taskComboBoxSelectedItem = value;
                OnPropertyChanged("TaskComboBoxSelectedItem");
            }
        }
        public ComboBoxItem FilterTaskCBoxSelectedItem
        {
            get { return _filterTaskCBoxSelectedItem; }
            set
            {
                _filterTaskCBoxSelectedItem = value;
                OnPropertyChanged("FilterTaskCBoxSelectedItem");
            }
        }
        public ComboBoxItem TaskStatusesSelectedItem
        {
            get { return _taskStatusesSelectedItem; }
            set
            {
                _taskStatusesSelectedItem = value;
                OnPropertyChanged("TaskStatusesSelectedItem");
            }
        }

        public User CurrentUser { get; set; }
        public Models.Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        public ObservableCollection<User> AllUsers { get; set; }
        public ObservableCollection<Models.TaskStatus> TaskStatuses { get; set; }
        public ObservableCollection<ComboBoxItem> FilterTaskCBoxItems { get; set; }
        public ObservableCollection<ComboBoxItem> TaskComboBoxItems
        {
            get { return _taskComboBoxItems; }
            set
            {
                _taskComboBoxItems = value;
                OnPropertyChanged("TaskComboBoxItems");
            }
        }
        public ObservableCollection<Models.Task> TasksAccepted
        {
            get { return _tasksAccepted; }
            set
            {
                _tasksAccepted = value;
                Helper.taskSystemContext.SaveChanges();
                OnPropertyChanged(nameof(TasksAccepted));
            }
        }
        public ObservableCollection<Models.Task> TasksAvailable
        {
            get { return _tasksAvailable; }
            set
            {
                _tasksAvailable = value;
                OnPropertyChanged("TasksAvailable");
            }
        }

        public ICommand TaskCBoxSelectionChangedCommand => _taskCBoxSelectionChangedCommand ??= new RelayCommand(TaskCBoxSelectionChanged);
        public ICommand TaskStatusCBoxSelectionChangedCommand => _taskStatusCBoxSelectionChangedCommand ??= new RelayCommand(TaskStatusCBoxSelectionChanged);
        public ICommand FilterTaskCBoxSelectionChangedCommand => _filterTaskCBoxSelectionChangedCommand ??= new RelayCommand(FilterTaskCBoxSelectionChanged);
        public ICommand AcceptTaskClickedCommand => _acceptTaskClickedCommand ??= new RelayCommand(AcceptTaskClicked);
        private void TaskCBoxSelectionChanged(object commandParameter)
        {
            UpdateTasksView();
        }
        private void TaskStatusCBoxSelectionChanged(object commandParameter)
        {
            UpdateTasksView();
        }
        private void FilterTaskCBoxSelectionChanged(object commandParameter)
        {
            UpdateTasksView();
        }
        private void AcceptTaskClicked(object commandParameter)
        {
            if (AcceptAndDeleteButtonContent == "Delete")
            {
                Helper.taskSystemContext.Tasks.Remove(SelectedTask);
                UpdateTasksView();
                Helper.taskSystemContext.SaveChanges();
                return;
            }
            SelectedTask.AcceptedUserId = Helper.currentUser.Id;
            SelectedTask.TaskStatusId = 1;
            Helper.taskSystemContext.SaveChanges();
            UpdateTasksView();
        }

        public void UpdateTasksView()
        {
            TasksAccepted = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.TaskStatusId != 2 && x.AcceptedUserId == Helper.currentUser.Id));
            TasksAvailable = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.TaskStatusId == 2));
            AcceptAndDeleteButtonContent = "Accept";
            if (TaskComboBoxSelectedItem != null)
                switch (TaskComboBoxSelectedItem.Name)
                {
                    case "allTasks":
                        {
                            //TasksAccepted = new ObservableCollection<Models.Task>(TasksAccepted.Where(x => x.TaskStatusId != 2 && x.AcceptedUserId == Helper.currentUser.Id));
                            break;
                        }
                    case "notFinishedTasks":
                        {
                            TasksAccepted = new ObservableCollection<Models.Task>(TasksAccepted.Where(x => x.TaskStatusId == 1));
                            break;
                        }
                    case "finishedTasks":
                        {
                            TasksAccepted = new ObservableCollection<Models.Task>(TasksAccepted.Where(x => x.TaskStatusId == 0));
                            break;
                        }
                }
            if (FilterTaskCBoxSelectedItem != null)
                switch (FilterTaskCBoxSelectedItem.Name)
                {
                    case "byDefault":
                        {
                            TasksAvailable = new ObservableCollection<Models.Task>(TasksAvailable.OrderBy(x => x.Id).Where(x => x.CreatorUserId != Helper.currentUser.Id));
                            break;
                        }
                    case "byDate":
                        {
                            TasksAvailable = new ObservableCollection<Models.Task>(TasksAvailable.OrderBy(x => x.PublicationDate).Where(x => x.CreatorUserId != Helper.currentUser.Id));
                            break;
                        }
                    case "byUserCBoxItem":
                        {
                            var text = FilterByUserText;
                            if (text != null)
                                TasksAvailable = new ObservableCollection<Models.Task>(
                                    TasksAvailable.Where(x => x.CreatorUser.Login.ToLower().Contains(text.ToLower()) ||
                                                              x.CreatorUser.FirstName.ToLower().Contains(text.ToLower()) ||
                                                              x.CreatorUser.Surname.ToLower().Contains(text.ToLower()) ||
                                                              x.CreatorUser.MiddleName.ToLower().Contains(text.ToLower()) ||
                                                              x.CreatorUser.PhoneNumber.ToLower().Contains(text.ToLower())
                                                              ).Where(x => x.CreatorUserId != Helper.currentUser.Id));
                            break;
                        }
                    case "myTasksCBoxItem":
                        {
                            AcceptAndDeleteButtonContent = "Delete";
                            TasksAvailable = new ObservableCollection<Models.Task>(TasksAvailable.OrderBy(x => x.Id).Where(x => x.CreatorUserId == Helper.currentUser.Id));
                            break;
                        }
                }
        }
        private string _acceptAndDeleteButtonContent;

        public string AcceptAndDeleteButtonContent
        {
            get { return _acceptAndDeleteButtonContent; }
            set { _acceptAndDeleteButtonContent = value; OnPropertyChanged(nameof(AcceptAndDeleteButtonContent)); }
        }


        public TaskSystemWindowViewModel()
        {
            CurrentUser = Helper.currentUser;
            AllUsers = new ObservableCollection<User>(Helper.taskSystemContext.Users.Where(x => x.Id != Helper.currentUser.Id));
            TasksAccepted = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.TaskStatusId != 2 && x.AcceptedUserId == CurrentUser.Id));
            TasksAvailable = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.TaskStatusId == 2));
            TaskComboBoxItems = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Name = "allTasks", Content = "All Tasks"/*, IsSelected = true*/ },
                new ComboBoxItem { Name = "notFinishedTasks", Content = "Tasks in proccess" },
                new ComboBoxItem { Name = "finishedTasks", Content = "Finished tasks" }
            };
            FilterTaskCBoxItems = new ObservableCollection<ComboBoxItem>
            {
                new ComboBoxItem { Name = "byDefault", Content = "By default", IsSelected = true },
                new ComboBoxItem { Name = "byDate", Content = "By date" },
                new ComboBoxItem { Name = "byUserCBoxItem", Content = "By user" },
                new ComboBoxItem { Name = "myTasksCBoxItem", Content = "My tasks" }
            };
            TaskStatuses = new ObservableCollection<Models.TaskStatus>(Helper.taskSystemContext.TaskStatuses);
            AcceptAndDeleteButtonContent = "Accept";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private RelayCommand _showTasksUserMadeCommand;
        private RelayCommand _showTasksUserAcceptCommand;
        //private RelayCommand _usersDGridSelectionChangedCommand;
        private ObservableCollection<Models.Task> _tasksOfSelectedUser;
        public ICommand ShowTasksUserMadeCommand => _showTasksUserMadeCommand ??= new RelayCommand(ShowTasksUserMade);
        public ICommand ShowTasksUserAcceptCommand => _showTasksUserAcceptCommand ??= new RelayCommand(ShowTasksUserAccept);
        //public ICommand UsersDGridSelectionChangedCommand => _usersDGridSelectionChangedCommand ??= new RelayCommand(UsersDGridSelectionChanged);



        public ObservableCollection<Models.Task> TasksOfSelectedUser
        {
            get { return _tasksOfSelectedUser; }
            set { _tasksOfSelectedUser = value; OnPropertyChanged(nameof(TasksOfSelectedUser)); }
        }
        //private void UsersDGridSelectionChanged(object commandParameter)
        //{

        //}
        private int _userMadeOrAccept = -1; // -1: undefined; 1: Show tasks user made; 2: Show tasks user accept
        private void ShowTasksUserMade(object commandParameter)
        {
                _userMadeOrAccept = 1;
            if (SelectedUser != null)
                TasksOfSelectedUser = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.CreatorUser.Id == SelectedUser.Id));

        }
        private void ShowTasksUserAccept(object commandParameter)
        {
                _userMadeOrAccept = 2;
            if (SelectedUser != null)
                TasksOfSelectedUser = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks.Where(x => x.AcceptedUser.Id == SelectedUser.Id));

        }
        private User _selectedUser;

        public User SelectedUser 
        { 
            get { return _selectedUser; }
            set 
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
                if (_userMadeOrAccept == 1)
                {
                    ShowTasksUserMade(value);
                    return;
                }
                if (_userMadeOrAccept == 2)
                {
                    ShowTasksUserAccept(value);
                    return;
                }
            }
        }

        private RelayCommand _addTaskBtnCommand;
        public ICommand AddTaskCommand => _addTaskBtnCommand ??= new RelayCommand(AddTask);

        private int _addTaskPressedCount = 0;
        private void AddTask(object commandParameter)
        {
            _addTaskPressedCount++;
            if (_addTaskPressedCount == 1)
                return;

            Models.Task task = new Models.Task
            {
                Title = NewTaskTitle,
                Description = NewTaskDescription,
                PublicationDate = DateTime.Now,
                CreatorUserId = Helper.currentUser.Id,
                AcceptedUserId = null,
                TaskStatusId = 2
            };
            Helper.taskSystemContext.Tasks.Add(task);
            _addTaskPressedCount = 0;
            if (!String.IsNullOrWhiteSpace(task.Title) && !String.IsNullOrWhiteSpace(task.Description))
            {
                Helper.taskSystemContext.SaveChanges();
                UpdateTasksView();
                NewTaskTitle = String.Empty;
                NewTaskDescription = String.Empty;
                return;
            }
            Helper.taskSystemContext.Remove(task);
            MessageBox.Show("Enter title and description of new task.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private string _newTaskTitle;
        private string _newTaskDescription;

        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set { _newTaskTitle = value; OnPropertyChanged(nameof(NewTaskTitle)); }
        }

        public string NewTaskDescription
        {
            get { return _newTaskDescription; }
            set { _newTaskDescription = value; OnPropertyChanged(nameof(NewTaskDescription)); }
        }

        private RelayCommand cancelAddTaskCommand;
        public ICommand CancelAddTaskCommand => cancelAddTaskCommand ??= new RelayCommand(CancelAddTask);

        private void CancelAddTask(object commandParameter)
        {
            _addTaskPressedCount = 0;
        }
        private RelayCommand _allUsersSelectionChangedCommand;
        public ICommand AllUsersSelectionChangedCommand => _allUsersSelectionChangedCommand ??= new RelayCommand(AllUsersSelectionChanged);

        private void AllUsersSelectionChanged(object commandParameter)
        {
            if (_userMadeOrAccept == 1)
            {
                ShowTasksUserMade(commandParameter);
                return;
            }
            if (_userMadeOrAccept == 2)
            {
                ShowTasksUserAccept(commandParameter);
                return;
            }
        }

        private RelayCommand logOutCommand;
        public ICommand LogOutCommand => logOutCommand ??= new RelayCommand(LogOut);

        private void LogOut(object commandParameter)
        {
            Helper.currentUser = null;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.Windows.OfType<TaskSystemWindow>().First().Close();
        }

        private RelayCommand updateAllUsersDGridCommand;
        public ICommand UpdateAllUsersDGridCommand => updateAllUsersDGridCommand ??= new RelayCommand(UpdateAllUsersDGrid);

        private void UpdateAllUsersDGrid(object commandParameter)
        {
            AllUsers = new ObservableCollection<User>(Helper.taskSystemContext.Users.Where(x => x.Id != Helper.currentUser.Id));
        }

        private RelayCommand openTasksReportWindowCommand;
        public ICommand OpenTasksReportWindowCommand => openTasksReportWindowCommand ??= new RelayCommand(OpenTasksReportWindow);

        private void OpenTasksReportWindow(object commandParameter)
        {
            ObservableCollection<Models.Task> allTasks = new ObservableCollection<Models.Task>(Helper.taskSystemContext.Tasks);
            TasksReportWindow tasksReportWindow = new TasksReportWindow(allTasks);
            tasksReportWindow.ShowDialog();

        }
    }
}

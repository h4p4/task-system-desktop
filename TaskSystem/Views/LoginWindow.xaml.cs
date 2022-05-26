using Microsoft.EntityFrameworkCore;
using System.Windows;
using TaskSystem.ViewModels;

namespace TaskSystem.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Helper.taskSystemContext.Users.Load();
            this.DataContext = new LoginWindowViewModel();
        }
        
        private void LogTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(LogTBlock, LogTBox);
        }
        private void LogTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(LogTBlock, LogTBox);
        }
        private void PassPBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PassTBlock, PassPBox);
        }
        private void PassPBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PassTBlock, PassPBox);
        }
    }
}

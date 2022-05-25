using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskSystem.ViewModels;
using TaskSystem.Models;
using TaskSystem.Views;

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

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
using System.Windows.Shapes;
using TaskSystem.ViewModels;

namespace TaskSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            Helper.taskSystemContext.Users.Load();
            this.DataContext = new SignUpWindowViewModel();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (SignUpCheck("Name", NameTBox) &&
            //    SignUpCheck("Surname", SurnameTBox) &&
            //    SignUpCheck("Middle Name", MidNameTBox) &&
            //    SignUpCheck("Phone Number", PhoneTBox) &&
            //    SignUpCheck("Login", LoginTBox) &&
            //    SignUpCheck("Password", PassPBox) &&
            //    SignUpCheck("Password", PassCheckPBox)
            //    )
            //{
            //    User? user = Helper.taskSystemContext.Users.FirstOrDefault(x => x.Login == LoginTBox.Text);

            //    if (PassCheckPBox.Password != PassPBox.Password)
            //    {
            //        MessageBox.Show("Passwords are different!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //    else
            //    {
            //        if (user == null)
            //        {
            //            var newUser = new User()
            //            {
            //                Login = LoginTBox.Text,
            //                Password = PassPBox.Password,
            //                FirstName = NameTBox.Text,
            //                Surname = SurnameTBox.Text,
            //                MiddleName = SurnameTBox.Text,
            //                PhoneNumber = PhoneTBox.Text
            //            };
            //            Helper.taskSystemContext.Users.Add(newUser);
            //            Helper.taskSystemContext.SaveChanges();
            //            LoginWindow loginWindow = new LoginWindow();
            //            loginWindow.Show();
            //            this.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("User already exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        }
            //    }
            //}
            //else MessageBox.Show("You must fill all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        //private bool SignUpCheck(string defaultText, TextBox textBox)
        //{
        //    if (textBox.Text != defaultText && textBox.Text != string.Empty)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //private bool SignUpCheck(string defaultPassword, PasswordBox passwordBox)
        //{
        //    if (passwordBox.Password != defaultPassword && passwordBox.Password != string.Empty)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void NameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(NameTBlock, NameTBox);
        }
        private void NameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(NameTBlock, NameTBox);
        }
        private void SurnameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(SurnameTBlock, SurnameTBox);
        }
        private void SurnameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(SurnameTBlock, SurnameTBox);
        }
        private void MidNameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(MidNameTBlock, MidNameTBox);
        }
        private void MidNameTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(MidNameTBlock, MidNameTBox);
        }
        private void PhoneTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PhoneTBlock, PhoneTBox);
        }
        private void PhoneTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PhoneTBlock, PhoneTBox);
        }
        private void LoginTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(LoginTBlock, LoginTBox);
        }
        private void LoginTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(LoginTBlock, LoginTBox);
        }
        private void PassPBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PassTBlock, PassPBox);
        }
        private void PassPBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Helper.HandleFocus(PassTBlock, PassPBox);
        }
        //private void PassCheckPBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    Helper.HandleFocus(NameTBlock, NameTBox);
        //}
        //private void PassCheckPBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    Helper.HandleFocus(NameTBlock, NameTBox);
        //}
        private void BackBtn_Click(object sender, RoutedEventArgs e) // viewmodel
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

    }
}

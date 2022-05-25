using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TaskSystem;
using TaskSystem.ViewModels;
using TaskSystem.Models;
using TaskSystem.Views;

namespace TaskSystem.ViewModels
{
    public class SignUpWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _signUpCommand;
        public ICommand SignUpCommand => _signUpCommand ??= new RelayCommand(SignUp);

        public string NewUserName { get; set; }
        public string NewUserSurname { get; set; }
        public string NewUserMidName { get; set; }
        public string NewUserPhoneNum { get; set; }
        public string NewUserLogin { get; set; }
        public string NewUserPassword { get; set; }
        public SignUpWindowViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        private void SignUp(object commandParameter)
        {
            if (!String.IsNullOrWhiteSpace(NewUserName) &&
                !String.IsNullOrWhiteSpace(NewUserSurname) &&
                !String.IsNullOrWhiteSpace(NewUserMidName) &&
                !String.IsNullOrWhiteSpace(NewUserPhoneNum) &&
                !String.IsNullOrWhiteSpace(NewUserLogin) &&
                !String.IsNullOrWhiteSpace(NewUserPassword)
                ) // check if empty
            {
                User? user = Helper.taskSystemContext.Users.FirstOrDefault(x => x.Login == NewUserLogin);


                if (user == null)
                {
                    var newUser = new User()
                    {
                        Login = NewUserName,
                        Password = NewUserSurname,
                        FirstName = NewUserMidName,
                        Surname = NewUserPhoneNum,
                        MiddleName = NewUserLogin,
                        PhoneNumber = NewUserPassword
                    };
                    Helper.taskSystemContext.Users.Add(newUser);
                    Helper.taskSystemContext.SaveChanges();

                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    Application.Current.Windows.OfType<SignUpWindow>().First().Close();
                }
                else
                {
                    MessageBox.Show("User already exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("You must fill all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

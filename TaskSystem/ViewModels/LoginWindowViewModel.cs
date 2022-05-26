using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TaskSystem.Models;
using TaskSystem.Views;

namespace TaskSystem.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        private string _enteredLogin;
        private string _enteredPassword;

        public string EnteredLogin
        {
            get { return _enteredLogin; }
            set
            {
                _enteredLogin = value;
                OnPropertyChanged("EnteredLogin");
            }
        }
        public string EnteredPassword
        {
            get { return _enteredPassword; }
            set
            {
                _enteredPassword = value;
                OnPropertyChanged("EnteredPassword");
            }
        }

        private RelayCommand _userLogInCommand;
        public RelayCommand UserLogInCommand
        {
            get 
            {
                return _userLogInCommand ??
                    (_userLogInCommand = new RelayCommand(obj =>
                    {
                        if (!String.IsNullOrWhiteSpace(EnteredLogin))
                        {
                            if (!String.IsNullOrWhiteSpace(EnteredPassword))
                            {
                                Helper.currentUser = Users.Where(x => x.Login == EnteredLogin && x.Password == EnteredPassword).FirstOrDefault();
                                if (Helper.currentUser == null) MessageBox.Show("Wrong login or password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                else
                                {
                                    TaskSystemWindow taskSystemWindow = new TaskSystemWindow();
                                    taskSystemWindow.Show();
                                    Application.Current.Windows.OfType<LoginWindow>().First().Close();
                                }
                            }
                            else MessageBox.Show("Enter your password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        else MessageBox.Show("Enter your login", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }));
            }
        }
        public ObservableCollection<User> Users { get; set; }
        public LoginWindowViewModel()
        {
            Users = new ObservableCollection<User>(Helper.taskSystemContext.Users);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private RelayCommand userSignUpCommand;
        public ICommand UserSignUpCommand => userSignUpCommand ??= new RelayCommand(UserSignUp);

        private void UserSignUp(object commandParameter)
        {
            SignUpWindow signUpWindow = new SignUpWindow(); 
            signUpWindow.Show();
            Application.Current.Windows.OfType<LoginWindow>().First().Close();
        }
    }
}

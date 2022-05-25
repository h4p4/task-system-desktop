using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TaskSystem.Models
{
    public partial class User : INotifyPropertyChanged
    {
        public User()
        {
            TaskAcceptedUsers = new HashSet<Task>();
            TaskCreatorUsers = new HashSet<Task>();
        }

        private int _id;
        private string _firstName;
        private string _surname;
        private string _middleName;
        private string _login;
        private string _password;
        private string _phoneNumber;


        public int Id 
        { get; set; }
        public string FirstName 
        { get; set; } = null!;
        public string Surname 
        { get; set; } = null!;
        public string MiddleName 
        { get; set; } = null!;
        public string Login
        { get; set; } = null!;
        //{
        //    get { return _login; }
        //    set
        //    {
        //        _login = value;
        //        OnPropertyChanged("Login");
        //    }
        //}
        public string Password
        { get; set; } = null!;
        //{
        //    get { return _password; }
        //    set
        //    {
        //        _password = value;
        //        OnPropertyChanged("Password");
        //    }
        //}
        public string PhoneNumber 
        { get; set; } = null!;

        public virtual ICollection<Task> TaskAcceptedUsers { get; set; }
        public virtual ICollection<Task> TaskCreatorUsers { get; set; }

        //private ICollection<Task> _taskAcceptedUsers;
        //private ICollection<Task> _taskCreatorUsers;

        //public virtual ICollection<Task> TaskAcceptedUsers
        //{
        //    get { return _taskAcceptedUsers; }
        //    set { _taskAcceptedUsers = value; OnPropertyChanged(nameof(TaskAcceptedUsers)); }
        //}
        //public virtual ICollection<Task> TaskCreatorUsers
        //{
        //    get { return _taskCreatorUsers; }
        //    set { _taskCreatorUsers = value; OnPropertyChanged(nameof(TaskCreatorUsers)); }
        //}


        private int _countOfAccepted;
        [NotMapped]
        public int CountOfAccepted
        {
            get { return TaskAcceptedUsers.Count(); }
            set
            {
                //_countOfAccepted = TaskAcceptedUsers.Count();
                OnPropertyChanged(nameof(TaskAcceptedUsers));
            }
        }
        private int _countOfCreated;
        [NotMapped]
        public int CountOfCreated
        {
            get { return TaskCreatorUsers.Count(); }
            set
            {
                //_countOfCreated = TaskCreatorUsers.Count();
                OnPropertyChanged(nameof(TaskCreatorUsers));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using TaskSystem.ViewModels;

namespace TaskSystem.Models
{
    public partial class Task : INotifyPropertyChanged
    {
        private TaskStatus _taskStatus;
        public int _taskStatusId;

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime PublicationDate { get; set; }
        public int CreatorUserId { get; set; }
        public int? AcceptedUserId { get; set; }
        public int TaskStatusId
        {
            get { return _taskStatusId; }
            set
            {
                _taskStatusId = value;
                OnPropertyChanged("TaskStatusId");
                RaisePropertyChanged(nameof(TaskStatusId));
            }
        }

        public virtual User? AcceptedUser { get; set; }
        public virtual User CreatorUser { get; set; } = null!;
        public virtual TaskStatus TaskStatus
        {
            get { return _taskStatus; }
            set
            {
                _taskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (propertyName == "TaskStatusId")
            {
                if (TaskStatusId == 2)
                {
                    AcceptedUserId = null;
                    Helper.taskSystemContext.SaveChanges();
                }

            }
            Helper.taskSystemContext.SaveChanges();

            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

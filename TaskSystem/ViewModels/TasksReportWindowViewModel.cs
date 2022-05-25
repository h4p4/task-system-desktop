using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskSystem;
using TaskSystem.Views;

namespace TaskSystem.ViewModels
{
    public class TasksReportWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Models.Task> _allTasks;

        public ObservableCollection<Models.Task> AllTasks
        {
            get { return _allTasks; }
            set { _allTasks = value; }
        }

        public TasksReportWindowViewModel(ObservableCollection<Models.Task> allTasks)
        {
            AllTasks = allTasks;
        }

        private string _savingFormat;

        //public string SavingFormat
        //{
        //    get { return _savingFormat; }
        //    set { _savingFormat = value; OnPropertyChanged(nameof(SavingFormat)); }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private RelayCommand cancelSavingCommand;
        public ICommand CancelSavingCommand => cancelSavingCommand ??= new RelayCommand(CancelSaving);

        private void CancelSaving(object commandParameter)
        {
            Application.Current.Windows.OfType<TasksReportWindow>().First().Close();
        }
    }
}

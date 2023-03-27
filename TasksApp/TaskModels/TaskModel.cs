using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksApp.TaskModels
{
    internal class TaskModel: INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool _isDone;
        private string _taskDiscription;


        public bool IsDone 
        { 
            get { return _isDone; } 
            set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            } 
        
        }
        public string TaskDiscription 
        { 
            get { return _taskDiscription; } 
            set 
            {
                if (_taskDiscription == value)
                    return;
                _taskDiscription = value;
                OnPropertyChanged("TaskDiscription");
            } 
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

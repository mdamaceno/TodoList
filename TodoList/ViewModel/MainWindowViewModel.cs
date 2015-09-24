using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TodoList.Access;
using TodoList.Access.Model;
using TodoList.Processing;

namespace TodoList.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        public Command CloseCommand { get; set; }
        public Command RemoveCommand { get; set; }
        public Command InsertCommand { get; set; }
        public Command EditCommand { get; set; }
        public MainWindowViewModel()
        {
            var task = TaskDAO.Entities.TaskEntity.actionIndex();
            var user = TaskDAO.Entities.UserEntity.actionIndex();

            this.tasks = new ObservableCollection<Task>(task);
        }

        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return this.tasks; }
            set
            {
                if (this.tasks == value)
                    return;

                this.tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return this.users; }
            set
            {
                if (this.users == value)
                    return;

                this.users = value;
                OnPropertyChanged("Users");
            }
        }
    }
}

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
            this.InsertCommand = new Command((p) => { this.Insert(); });

            this.created_at = DateTime.Now;

            var task = TaskDAO.Entities.TaskEntity.actionIndex();
            var users = TaskDAO.Entities.UserEntity.actionIndex();

            this.tasks = new ObservableCollection<Task>(task);
            this.users = new ObservableCollection<User>(users);
        }

        private MainWindow view;
        public MainWindow View
        {
            get { return this.view; }
            set
            {
                this.view = value;
            }
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

        private void Insert()
        {
            var task = new Task()
            {
                Title = this.title,
                Description = this.description,
                User = this.UserSelected
            };

            TaskDAO.Entities.TaskEntity.actionCreate(task);

            var t = TaskDAO.Entities.TaskEntity.actionIndex();

            this.Tasks = new ObservableCollection<Task>(t);

            this.view.grdTask.Items.Refresh();
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

        private User userSelected;
        public User UserSelected
        {
            get { return this.userSelected; }
            set
            {
                if (this.userSelected == value)
                    return;

                this.userSelected = value;
                OnPropertyChanged("UserSelected");
            }
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title == value)
                    return;

                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        private string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description == value)
                    return;

                this.description = value;
                OnPropertyChanged("Title");
            }
        }

        private DateTime created_at;
        public DateTime CreatedAt
        {
            get { return this.created_at; }
            set
            {
                if (this.created_at == value)
                    return;

                this.created_at = value;
                OnPropertyChanged("CreatedAt");
            }
        }
    }
}

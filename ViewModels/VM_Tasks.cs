using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TaskManager_Kylosov.Classes;
using TaskManager_Kylosov.Context;
using TaskManager_Kylosov.Models;

namespace TaskManager_Kylosov.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();
        public ObservableCollection<Tasks> Tasks { get; set; }

        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));

        public RelayCommand OnAddTask
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        Tasks NewTask = new Tasks()
                        {
                            DateExecute = DateTime.Now
                        };

                        Tasks.Add(NewTask);
                        tasksContext.Tasks.Add(NewTask);
                        tasksContext.SaveChanges();
                    }
                );
            }
        }

        public string findName;

        public string FindName
        {
            get
            {
                return findName;
            }
            set
            {
                findName = value;

                if(string.IsNullOrEmpty(findName))
                    Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
                else 
                    Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.Where(x => x.Name == findName));

                MainWindow.Instance.Frame.Navigate(new View.Main(this));
            }
        }
    }
}

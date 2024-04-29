using TaskManager_Kylosov.Context;
using TaskManager_Kylosov.Classes;
using System.Collections.ObjectModel;
using System;
using TaskManager_Kylosov.Models;
using System.Windows;

namespace TaskManager_Kylosov.ViewModels
{
    public class VM_Priority : Notification
    {
        public PriorityContext priorityContext = new PriorityContext();
        public ObservableCollection<Priority> Priority { get; set; }

        public VM_Priority() {
            Priority = new ObservableCollection<Priority>(priorityContext.Priority);
        }

        public RelayCommand OnAddPriority
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        Priority priority = new Priority();

                        this.Priority.Add(priority);
                        priorityContext.Priority.Add(priority);
                        priorityContext.SaveChanges();
                    }
                );
            }
        }
    }
}

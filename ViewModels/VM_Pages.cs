using System;
using System.Collections.Generic;
using System.Text;
using TaskManager_Kylosov.Classes;
using TaskManager_Kylosov.View;

namespace TaskManager_Kylosov.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();
        public VM_Pages() 
        {
            MainWindow.Instance.Frame.Navigate(new View.Main(vm_tasks));
        }

        public RelayCommand OnClose
        {
            get
            {
                return new RelayCommand(obj => { MainWindow.Instance.Close(); });
            }
        }
    }
}

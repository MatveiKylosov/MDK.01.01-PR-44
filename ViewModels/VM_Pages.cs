using System.Windows;
using TaskManager_Kylosov.Classes;

namespace TaskManager_Kylosov.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();
        public VM_Priority vm_priority = new VM_Priority();
        public VM_Pages()
        {
            MainWindow.Instance.Frame.Navigate(new View.PriorityFolder.Main(vm_priority));
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

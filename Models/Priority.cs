using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using TaskManager_Kylosov.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;
namespace TaskManager_Kylosov.Models
{
    public class Priority : Notification
    {
        public int Id { get; set; }
        private string namePriority;
        public string NamePriority
        {
            get { return namePriority; }
            set
            {
                Match match = Regex.Match(value, "^.{1,30}$");
                if (!match.Success)
                    MessageBox.Show($"Наименование не должно быть пустым, и не более 30 символов. ${value}$", "Не корретный ввод значениея.");

                else
                {
                    namePriority = value;
                    OnPropertyChanged("NamePriority");
                }            
            }
        }

        [Schema.NotMapped]
        private bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }

        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (isEnable) return "Сохранить";
                else return "Изменить";
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    IsEnable = !IsEnable;

                    if (!IsEnable)
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_priority.priorityContext.SaveChanges();
                }
                );

            }
        }

        [Schema.NotMapped]
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены что хотите удалить задачу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_priority.Priority.Remove(this); // del in form
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_priority.priorityContext.Remove(this);
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_priority.priorityContext.SaveChanges();
                    }
                }
                );
            }
        }
    }
}

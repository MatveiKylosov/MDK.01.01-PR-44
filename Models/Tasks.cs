﻿using TaskManager_Kylosov.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using TaskManager_Kylosov.Context;


namespace TaskManager_Kylosov.Models
{
    public class Tasks : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success)
                    MessageBox.Show($"Наименование не должно быть пустым, и не более 50 символов. ${value}$", "Не корретный ввод значениея.");

                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private int? priorityId;
        public int? PriorityId
        {
            get 
            {
                return priorityId; 
            }
            set
            {
                priorityId = value;
                OnPropertyChanged("PriorityId");
            }
        }


        private DateTime dateExecute;

        public DateTime DateExecute
        {
            get { return dateExecute; }
            set
            {
                if (value.Date < DateTime.Now.Date)
                    MessageBox.Show("Дата выполнения не может быть меньшей текущей.", "Не корретный ввод значения.");

                else
                {
                    dateExecute = value;
                    OnPropertyChanged("DateExecute");
                }
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                Match match = Regex.Match(value, "^.{1,1000}$");
                if (!match.Success)
                    MessageBox.Show($"Комментарий не должен быть пустым, и не более 1000 символов.", "Не корректный воод значнения.");

                else
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        private bool done;
        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
                OnPropertyChanged("Done");
                OnPropertyChanged("IsDoneText");
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
        public string IsDoneText
        {
            get
            {
                if (Done) return "Не выполнено";
                else return "Выполнено";
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
                            (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
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
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_tasks.Tasks.Remove(this); // del in form
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.Instance.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                }
                );

            }
        }

        [Schema.NotMapped]
        public RelayCommand OnDone
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Done = !Done;
                }
                );
            }
        }

        [Schema.NotMapped]
        public ObservableCollection<Priority> Priority { get { return new ObservableCollection<Priority>(new PriorityContext().Priority); } }
    }
}

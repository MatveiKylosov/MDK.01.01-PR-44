using System.Windows;
using TaskManager_Kylosov.ViewModels;

namespace TaskManager_Kylosov
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlПроработанная структура и реализованное главное окно
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            DataContext = new VM_Pages();
        }
    }
}

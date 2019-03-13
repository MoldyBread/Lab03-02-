using System.Windows;


namespace KMA.ProgrammingInCSharp2019.Lab03_02_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonControlViewModel();
        }
    }
}

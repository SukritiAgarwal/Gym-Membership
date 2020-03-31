using GymMembers.ViewModel;
using System.Windows;

namespace GymMembers.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable
    {
        public MainWindow()
        {
            InitializeComponent();
            // DataContext = this;
        }
    }
}
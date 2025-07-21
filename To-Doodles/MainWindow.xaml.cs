using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_Doodles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new TaskManager();
        var manager = (TaskManager)DataContext;
        manager.CreateNewTask("Test Task", "This is a test description.", 1, 2, 3, 4);

    }

    private void OpenTaskUI_Click(object sender, RoutedEventArgs e)
    {
        TaskUI.Content = new TaskUI();
    }
}

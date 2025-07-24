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
        //manager.CreateNewTask("Test Task", "This is a test description.", 1, 2, 3, 4);

    }

    private void DropDownButton_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button?.ContextMenu != null)
        {
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.IsOpen = true;
        }

    }
    private void OpenDeletePopUp_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        var task = menuItem?.DataContext as Task;
        var manager = (TaskManager)DataContext;

        if (task != null)
        {
            var result = MessageBox.Show(
                "Do you really want to delete the task?",
                "approve delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                manager.DeleteTask(task);
                MessageBox.Show("Task deleted.");
            }
        }
        else
        {
            MessageBox.Show("Error: Task not found.");
        }
    }

    private void OpenTaskUI_Click(object sender, RoutedEventArgs e)
    {
        ModalOverlay.Visibility = Visibility.Visible;
    }

   
}

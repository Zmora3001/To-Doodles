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

public partial class EditTaskUI : UserControl
{
    public EditTaskUI()
    {
        InitializeComponent();
        // wichtig!
    }
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        // Versucht, das UserControl aus seinem Parent-Panel zu entfernen
        if (Window.GetWindow(this) is MainWindow mainWindow)
        {
            mainWindow.EditModalOverlay.Visibility = Visibility.Collapsed;
        }
        else
        {
            // Falls das Parent kein Panel ist, wird das UserControl ausgeblendet
            this.Visibility = Visibility.Collapsed;
        }
    }

    private void ChangeButton_CLick(object sender, RoutedEventArgs e)
    {
        // Get the task from DataContext
        var task = DataContext as Task;

        if (task != null)
        {
            // Validation checks remain the same
            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                MessageBox.Show("Bitte Titel und Beschreibung ausfüllen.");
                return;
            }

            if (!int.TryParse(WisdomBox.Text, out int wisdom) ||
                !int.TryParse(PatienceBox.Text, out int patience) ||
                !int.TryParse(FunBox.Text, out int fun) ||
                !int.TryParse(CreativityBox.Text, out int creativity))
            {
                MessageBox.Show("Bitte gültige Zahlen für alle Eigenschaften eingeben.");
                return;
            }

            // Update task properties
            task.Title = TitleBox.Text;
            task.Description = DescriptionBox.Text;
            task.WisdomExp = wisdom;
            task.PatienceExp = patience;
            task.FunExp = fun;
            task.CreativityExp = creativity;

            // Use the static TaskManager instance instead of trying to get it from DataContext
            MainWindow.ManagerInstance.UpdateTask(task);

            CloseButton_Click(sender, e);
        }
    }
}

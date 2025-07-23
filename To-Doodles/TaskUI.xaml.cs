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

    public partial class TaskUI : UserControl
{
    public TaskUI()
    {
        InitializeComponent(); // wichtig!
    }
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        // Versucht, das UserControl aus seinem Parent-Panel zu entfernen
        if (Window.GetWindow(this) is MainWindow mainWindow)
        {
            mainWindow.ModalOverlay.Visibility = Visibility.Collapsed;
        }
        else
        {
            // Falls das Parent kein Panel ist, wird das UserControl ausgeblendet
            this.Visibility = Visibility.Collapsed;
        }
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var taskManager = (TaskManager)DataContext;

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

        var newTask = taskManager.CreateNewTask(
            TitleBox.Text,
            DescriptionBox.Text,
            wisdom,
            patience,
            fun,
            creativity
        );

        CloseButton_Click(sender, e);
    }

}

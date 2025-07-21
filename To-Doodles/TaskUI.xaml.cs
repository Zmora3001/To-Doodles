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
        if (this.Parent is Panel panel)
        {
            panel.Children.Remove(this);
        }
        else
        {
            // Falls das Parent kein Panel ist, wird das UserControl ausgeblendet
            this.Visibility = Visibility.Collapsed;
        }
    }
}

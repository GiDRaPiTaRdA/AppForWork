using System.Windows;
using AppForWork2.View;
using AppForWork2.ViewModel;

namespace AppForWork2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
            mainWindow.Show();

        }

    }
}

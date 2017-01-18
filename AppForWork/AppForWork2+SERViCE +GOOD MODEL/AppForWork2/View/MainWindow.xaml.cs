using System;
using System.Diagnostics;
using System.Windows;
using AppForWork2.ViewModel;

namespace AppForWork2.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}

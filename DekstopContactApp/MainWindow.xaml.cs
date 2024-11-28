using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DekstopContactApp
{
    /*public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new();
            newContactWindow.ShowDialog();
        }
    }*/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = ((App)Application.Current)._serviceProvider.GetService<NewContactWindow>();
            newContactWindow?.ShowDialog();
        }
    }

}
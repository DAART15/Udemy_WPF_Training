using System.Windows;

namespace DekstopContactApp
{
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // save contact
            Close();
        }
    }
}

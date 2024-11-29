using DekstopContactApp.Interfaces;
using DekstopContactApp.Modules;
using System.Windows;

namespace DekstopContactApp
{
    public partial class NewContactWindow : Window
    {
        private readonly IContactRepository _contactRepository;

        public NewContactWindow(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contact contact = new()
                {
                    Name = nameTextBox.Text,
                    Email = emailTextBox.Text,
                    Phone = phoneTextBox.Text
                };
                await _contactRepository.AddContactAsync(contact);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}

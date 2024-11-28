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
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            InitializeComponent();
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
                MessageBox.Show("Contact added successfully.","Success", MessageBoxButton.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "ERROR", MessageBoxButton.OK);
            }
        }
    }

}

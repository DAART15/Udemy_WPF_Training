using DekstopContactApp.Interfaces;
using DekstopContactApp.Modules;
using System.Windows;

namespace DekstopContactApp.Windows
{
    public partial class UpdateContactWindow : Window
    {
        private readonly IContactRepository _contactRepository;
        public Contact contact;
        public UpdateContactWindow(Contact contact, IContactRepository contactRepository)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.contact = contact;
            _contactRepository = contactRepository;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private async void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                contact.Name = nameTextBox.Text;
                contact.Email = emailTextBox.Text;
                contact.Phone = phoneTextBox.Text;
                await _contactRepository.UpdateContactAsync(contact);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating contact: {ex.Message}", "ERROR", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}

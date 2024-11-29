using DekstopContactApp.Interfaces;
using DekstopContactApp.Modules;
using DekstopContactApp.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace DekstopContactApp
{
    public partial class MainWindow : Window
    {
        //private readonly IContactRepository contactRepository = ((App)Application.Current)._serviceProvider.GetService<IContactRepository>()!;
        private readonly IContactRepository _contactRepository;
        private List<Contact> _contacts = [];
        public MainWindow(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            InitializeComponent();
            DeleteContactButton.IsEnabled = false;
            UpdateContactButton.IsEnabled = false;
            _ = ReadFromDtaBase();
        }

        private async void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            var newContactWindow = ((App)Application.Current)._serviceProvider.GetService<NewContactWindow>();
            newContactWindow?.ShowDialog();
            await ReadFromDtaBase();
        }
        async Task ReadFromDtaBase() 
        {
            searchTextBox.Text = "";
            var contacts = await _contactRepository.GetAllContactsAsync();
            if (contacts == null) return;
            _contacts = contacts.OrderBy(n => n.Name).ToList();
            contactListView.ItemsSource = _contacts;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? searchTextBox = sender as TextBox;
            var filteredList = _contacts.Where(c => 
                   c.Name.ToLower().Contains(searchTextBox!.Text.ToLower()) 
                || c.Email.ToLower().Contains(searchTextBox!.Text.ToLower()) 
                || c.Phone.ToLower().Contains(searchTextBox!.Text.ToLower()))
                .ToList();
            contactListView.ItemsSource = filteredList;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(contactListView.SelectedItem is null)return;
            var contact = (Contact)contactListView.SelectedItem;
            await _contactRepository.DeleteContactAsync(contact);
            await ReadFromDtaBase();
        }

        private async void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            if (contactListView.SelectedItem is null) return;
            var contact = (Contact)contactListView.SelectedItem;
            var updateContactWindow = new UpdateContactWindow(contact, _contactRepository); //veikia ir taip
            //var updateContactWindow = ActivatorUtilities.CreateInstance<UpdateContactWindow>(((App)Application.Current)._serviceProvider, contact);
            updateContactWindow?.ShowDialog();
            await ReadFromDtaBase();
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteContactButton.IsEnabled = contactListView.SelectedItem != null;
            UpdateContactButton.IsEnabled = contactListView.SelectedItem != null;
        }
    }
}
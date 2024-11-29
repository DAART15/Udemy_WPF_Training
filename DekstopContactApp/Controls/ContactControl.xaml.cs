using DekstopContactApp.Modules;
using System.Windows;
using System.Windows.Controls;

namespace DekstopContactApp.Controls
{
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContactControl control)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact)!.Name;
                control.emailTextBlock.Text = (e.NewValue as Contact)!.Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact)!.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}

using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageUpload
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg;*.PNG;*.JPEG;*.JPG; | All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //naudoja mano kompiuterio direktorija kaip pradini dialogo atodarymo taska
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(filePath));
            }
        }
    }
}
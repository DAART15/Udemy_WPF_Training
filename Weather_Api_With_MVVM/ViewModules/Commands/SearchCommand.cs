using System.Windows.Input;

namespace Weather_Api_With_MVVM.ViewModules.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public SearchCommand(WeatherVM weatherVM) 
        {
            VM = weatherVM;
        }

        public bool CanExecute(object? parameter)
        {
            string query = (string)parameter;
            if (string.IsNullOrWhiteSpace(query) || query.Length < 3)
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.MakeQuery();
        }
    }
}

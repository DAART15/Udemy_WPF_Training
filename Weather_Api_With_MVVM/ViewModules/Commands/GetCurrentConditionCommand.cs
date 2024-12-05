using System.Windows.Input;

namespace Weather_Api_With_MVVM.ViewModules.Commands
{
    public class GetCurrentConditionCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;
        public GetCurrentConditionCommand(WeatherVM vm) 
        { 
            VM = vm; 
        }

        public bool CanExecute(object? parameter)
        {
            if (VM.SelectedCity == null)
            {
                return false;
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.GetWeather();
        }
    }
}

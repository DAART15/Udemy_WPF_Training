using System.Windows.Input;

namespace NotebookNotes.ViewModels.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM LoginVM { get; set; }
        public event EventHandler? CanExecuteChanged;
        public RegisterCommand(LoginVM loginVM) 
        {
            LoginVM = loginVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            // register functionality
        }
    }
}

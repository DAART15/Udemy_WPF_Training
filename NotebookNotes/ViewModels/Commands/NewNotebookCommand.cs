using System.Windows.Input;

namespace NotebookNotes.ViewModels.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesVM NotesVM { get; set; }
        public event EventHandler? CanExecuteChanged;
        public NewNotebookCommand(NotesVM notesVM)
        {
            NotesVM = notesVM;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            NotesVM.CreateNotebook();
        }

        
    }
}

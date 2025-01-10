using NotebookNotes.Models;
using System.Windows.Input;

namespace NotebookNotes.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM NotesVM { get; set; }
        public event EventHandler? CanExecuteChanged;
        public NewNoteCommand(NotesVM notesVM)
        {
            NotesVM = notesVM;
        }

        public bool CanExecute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            NotesVM.CreateNote(selectedNotebook.NotebookId);
        }
    }
}

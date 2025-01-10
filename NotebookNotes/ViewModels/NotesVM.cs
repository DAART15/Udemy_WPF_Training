using NotebookNotes.Models;
using NotebookNotes.Repositories;
using NotebookNotes.ViewModels.Commands;
using System.Collections.ObjectModel;

namespace NotebookNotes.ViewModels
{
    public class NotesVM
    {
        private readonly NoteRepository _noteRepository;
        private readonly NotebookRepository _notebookRepository;
        public ObservableCollection<Notebook> Notebooks { get; set; }
		private Notebook selectedNotebook;

		public Notebook SelectedNotebook
		{
			get { return selectedNotebook; }
			set 
			{ 
				selectedNotebook = value;
                // load notes
            }
        }
		public ObservableCollection<Note> Notes { get; set; }
		public NewNotebookCommand NewNotebookCommand { get; set; }
		public NewNoteCommand NewNoteCommand { get; set; }
        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }
        public NotesVM(NoteRepository noteRepository, NotebookRepository notebookRepository)
        {
            _noteRepository = noteRepository;
            _notebookRepository = notebookRepository;
        }
        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                Title = "New Note",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _noteRepository.CreateNote(newNote);
        }
        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New Notebook"
            };
            _notebookRepository.CreateNotebook(newNotebook);
        }
    }
}

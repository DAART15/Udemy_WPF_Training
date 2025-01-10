using NotebookNotes.DataBase;
using NotebookNotes.Models;

namespace NotebookNotes.Repositories
{
    public class NoteRepository
    {
        private readonly AppDbContext _dbContext;
        public NoteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNote(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
        }
    }
}

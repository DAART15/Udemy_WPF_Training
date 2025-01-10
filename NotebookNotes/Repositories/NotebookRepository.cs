using NotebookNotes.DataBase;
using NotebookNotes.Models;

namespace NotebookNotes.Repositories
{
    public class NotebookRepository
    {
        private readonly AppDbContext _dbContext;
        public NotebookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNotebook(Notebook notebook)
        {
            _dbContext.Notebooks.Add(notebook);
            _dbContext.SaveChanges();
        }
    }
}

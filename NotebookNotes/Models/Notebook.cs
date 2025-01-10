using System.ComponentModel.DataAnnotations;

namespace NotebookNotes.Models
{
    public class Notebook
    {

        public int NotebookId { get; set; }
        [Required]
        public User User { get; set; }
        public int UserId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public IList<Note>? Notes { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;

namespace NotebookNotes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        [Required]
        public Notebook Notebook { get; set; }
        public int NotebookId { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        //public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? FileLocation { get; set; }
    }
}

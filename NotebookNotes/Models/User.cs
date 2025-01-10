using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotebookNotes.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(50), Column("First_Name")]
        public string Name { get; set; }
        [Required, MaxLength(50), Column("Last_Name")]
        public string Lastname { get; set; }
        [Required, MaxLength(20), Column("User_Name")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public IList<Notebook>? Notebooks { get; set; } = [];
    }
}

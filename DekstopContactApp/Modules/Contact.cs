using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DekstopContactApp.Modules
{
    [Table("Contacts")]
    public class Contact
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required, MaxLength(50), Column("Name")]
        public string Name { get; set; }
        [Required, MaxLength(50), Column("E_Mail")]
        public string Email { get; set; }
        [Required, MaxLength(15), Column("PhoneNumber")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} {Email} {Phone}";
        }
    }
}

using DekstopContactApp.Modules;
using Microsoft.EntityFrameworkCore;

namespace DekstopContactApp.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=RAMAS\\SQLEXPRESS;Initial Catalog=WPF_Contact_App;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}

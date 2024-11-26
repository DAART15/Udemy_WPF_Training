using DekstopContactApp.Modules;
using Microsoft.EntityFrameworkCore;

namespace DekstopContactApp.DataBase
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DekstopContactsAppDataBase.db");
        }
    }
}

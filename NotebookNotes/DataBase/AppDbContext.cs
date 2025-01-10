using Microsoft.EntityFrameworkCore;
using NotebookNotes.Models;

namespace NotebookNotes.DataBase
{
    public class AppDbContext : DbContext
    {

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=RAMAS\\SQLEXPRESS;Initial Catalog=WPF_Notebook_Notes;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Admin", Lastname = "Admin", Username = "admin", Password = "admin" }
            );

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasMany(u => u.Notebooks)
                      .WithOne(nb => nb.User)
                      .HasForeignKey(nb => nb.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Notebook>(entity =>
            {
                entity.HasKey(nb => nb.NotebookId);
                entity.HasOne(nb => nb.User)
                      .WithMany(u => u.Notebooks)
                      .HasForeignKey(nb => nb.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(nb => nb.Notes)
                      .WithOne(n => n.Notebook)
                      .HasForeignKey(n => n.NotebookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(n => n.NoteId);
                entity.HasOne(n => n.Notebook)
                      .WithMany(nb => nb.Notes)
                      .HasForeignKey(n => n.NotebookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PrivateNote.Core.Models;

namespace PrivateNote.EntityFramework
{
    public sealed class NoteContext : DbContext
    {
        private string connectionString;
        public DbSet<Note> Notes { get; set; }

        public NoteContext(string connection)
        {
            connectionString = connection;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
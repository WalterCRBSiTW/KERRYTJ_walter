using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Homework02.Models
{
    public partial class HomeworkDBContext : DbContext
    {
        public HomeworkDBContext()
        {
        }

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Master> Master { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=HomeworkDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Master>(entity =>
            {
                entity.ToTable("master");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}

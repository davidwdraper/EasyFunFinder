using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyFunFinder.Data.Logger
{
    public partial class LoggerContext : DbContext
    {
        public virtual DbSet<LogEntry> LogEntry { get; set; }
        public virtual DbSet<LogLevel> LogLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=effdb.database.windows.net;Initial Catalog=Logger;Persist Security Info=True;User ID=davidwdraper@effdb.database.windows.net;Password=Caren4Me1010");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_Entry_CategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EntryDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExceptionText).HasColumnType("varchar(max)");

                entity.Property(e => e.Message).HasColumnType("varchar(500)");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
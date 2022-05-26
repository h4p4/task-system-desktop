using Microsoft.EntityFrameworkCore;
using TaskSystem.Models;

namespace TaskSystem
{
    public partial class TaskSystemContext : DbContext
    {
        public TaskSystemContext()
        {
        }
        public TaskSystemContext(DbContextOptions<TaskSystemContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskSystem");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.PublicationDate).HasColumnType("datetime");
                entity.Property(e => e.TaskStatusId).HasDefaultValueSql("(N'Выполняется')");
                entity.Property(e => e.Title).HasMaxLength(50);
                entity.HasOne(d => d.AcceptedUser)
                    .WithMany(p => p.TaskAcceptedUsers)
                    .HasForeignKey(d => d.AcceptedUserId)
                    .HasConstraintName("FK_Tasks_Users1");
                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.TaskCreatorUsers)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Users");
                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskStatus1");
            });
            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");
                entity.Property(e => e.Title).HasMaxLength(50);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Login).HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.Surname).HasMaxLength(50);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

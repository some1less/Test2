using Microsoft.EntityFrameworkCore;
using Test2.DAL.models;
using Task = Test2.DAL.models.Task;

namespace Test2.DAL.context;

public partial class RecordManiaContext : DbContext
{
    
    public RecordManiaContext(){}
    public RecordManiaContext(DbContextOptions<RecordManiaContext> options) : base(options){}
    
    public DbSet<Record> Records { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Task> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.HasIndex(r => r.Name).IsUnique();
            entity.HasMany(r => r.Records)
                .WithOne(r => r.Language)
                .HasForeignKey(r => r.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.HasIndex(r => r.Email).IsUnique();
            
            entity.Property(r => r.FirstName).HasMaxLength(100).IsUnicode();
            entity.Property(r => r.LastName).HasMaxLength(100).IsUnicode();
            
            entity.Property(e => e.Email).HasMaxLength(250).IsUnicode();
            
            entity.HasMany(e=>e.Records)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.HasIndex(r => r.Name).IsUnique();
            entity.HasMany(r => r.Records)
                .WithOne(r => r.Task)
                .HasForeignKey(r => r.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Record>(entity =>
        {
            entity.ToTable("Record");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ExecutionTime);

            entity.HasOne(d => d.Language).WithMany(p => p.Records)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Record_Language");

            entity.HasOne(d => d.Task).WithMany(p => p.Records)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Record_Task");
            
            entity.HasOne(d => d.Student).WithMany(p => p.Records)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Record_Student");
        });
        
        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
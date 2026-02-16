using Microsoft.EntityFrameworkCore;
using Task.net.Domain.Entities;

// Даем псевдоним для нашей сущности Task, чтобы не путать с системной
using TaskEntity = Task.net.Domain.Entities.Task;

namespace Task.net.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Department> Departments { get; set; }
    // Используем псевдоним TaskEntity вместо Task
    public DbSet<TaskEntity> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Уникальные индексы
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Name)
            .IsUnique();
            
        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Code)
            .IsUnique();
            
        modelBuilder.Entity<Permission>()
            .HasIndex(p => p.Code)
            .IsUnique();
            
        // Настройка связи многие-ко-многим Role-Permission
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });
            
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);
            
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);
            
        // Настройка связей Task - используем TaskEntity
        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.CreatedByUser)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.AssignedToUser)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Значения по умолчанию
        modelBuilder.Entity<TaskEntity>()
            .Property(t => t.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
            
        modelBuilder.Entity<TaskEntity>()
            .Property(t => t.Status)
            .HasDefaultValue(Task.net.Domain.Enums.TaskStatus.New);
            
        modelBuilder.Entity<TaskEntity>()
            .Property(t => t.Priority)
            .HasDefaultValue(Task.net.Domain.Enums.TaskPriority.Medium);
    }
}
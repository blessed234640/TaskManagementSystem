// Пользователь системы

using System.Collections.Generic;

namespace Task.net.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty; // Полное имя
    public string Email { get; set; } = string.Empty; // Email (уникальный)
    public string? PasswordHash { get; set; } // Хеш пароля (для аутентификации)
    
    // Foreign keys - внешние ключи для связей с другими таблицами
    public int DepartmentId { get; set; } // К какому отделу относится
    public int RoleId { get; set; } // Какая роль у пользователя
    
    // Navigation properties - навигационные свойства
    // Пользователь belongs to (принадлежит) одному отделу
    // Department? - может быть null если пользователь без отдела
    public Department? Department { get; set; }
    
    // Пользователь имеет одну роль
    public Role? Role { get; set; }
    
    // Задачи, которые создал этот пользователь
    // У одного пользователя может быть много созданных задач
    public ICollection<Task> CreatedTasks { get; set; } = new List<Task>();
    
    // Задачи, которые назначены этому пользователю
    public ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
}

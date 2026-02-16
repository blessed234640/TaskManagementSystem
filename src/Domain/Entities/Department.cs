// Отдел - структурная единица компании
// Например: IT, Бухгалтерия, HR

using System.Collections.Generic;

namespace Task.net.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty; // Название отдела "IT"
    public string? Description { get; set; } // Описание "Отдел разработки"
    
    // Связь с пользователями: в одном отделе много сотрудников
    public ICollection<User> Users { get; set; } = new List<User>();
}
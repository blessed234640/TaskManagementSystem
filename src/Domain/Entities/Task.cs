// Задача - основная сущность приложения

using System;
using Task.net.Domain.Enums; // Подключаем наши Enums

// Даем псевдоним нашему enum чтобы явно указать какой использовать
using TaskStatus = Task.net.Domain.Enums.TaskStatus;

namespace Task.net.Domain.Entities;

// Task - название класса, но чтобы не путать с System.Threading.Tasks
// используем using alias
public class Task : BaseEntity
{
    public string Title { get; set; } = string.Empty; // Заголовок задачи
    public string? Description { get; set; } // Описание задачи
    
    // Используем наши Enums для ограничения значений
    public TaskStatus Status { get; set; } = TaskStatus.New; // По умолчанию "Новая"
    public TaskPriority Priority { get; set; } = TaskPriority.Medium; // По умолчанию "Средний"
    
    public DateTime? CompletedAt { get; set; } // Когда выполнена (null если не выполнена)
    
    // Foreign keys
    public int CreatedByUserId { get; set; } // Кто создал задачу
    public int AssignedToUserId { get; set; } // Кому назначена
    
    // Navigation properties
    public User? CreatedByUser { get; set; } // Создатель задачи
    public User? AssignedToUser { get; set; } // Исполнитель
}
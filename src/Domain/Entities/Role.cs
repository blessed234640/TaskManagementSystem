// Роль определяет, что пользователь может делать в системе

using System.Collections.Generic; // Для использования ICollection

namespace Task.net.Domain.Entities;

// : BaseEntity - наследуем все поля от BaseEntity (Id, CreatedAt, и т.д.)
public class Role : BaseEntity
{
    // string? - nullable строка (может быть null)
    // = string.Empty; - инициализируем пустой строкой чтобы избежать null
    public string Name { get; set; } = string.Empty; // Отображаемое имя "Начальник"
    
    public string Code { get; set; } = string.Empty; // Код для программы "BOSS"
    
    public string? Description { get; set; } // Описание роли
    
    // Navigation properties - навигационные свойства для связей с другими таблицами
    
    // Связь с пользователями: у одной роли может быть много пользователей
    // ICollection - интерфейс для коллекции (List, HashSet и т.д.)
    // new List<User>() - создаем пустой список чтобы не было null
    public ICollection<User> Users { get; set; } = new List<User>();
    
    // Связь с разрешениями через промежуточную таблицу (many-to-many)
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
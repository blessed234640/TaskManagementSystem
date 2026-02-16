// Разрешение - это конкретное действие, которое можно выполнять
// Например: CREATE_TASK (создавать задачи), DELETE_TASK (удалять задачи)

using System.Collections.Generic;

namespace Task.net.Domain.Entities;

public class Permission : BaseEntity
{
    public string Code { get; set; } = string.Empty; // Код разрешения "CREATE_TASK"
    public string? Description { get; set; } // Описание "Может создавать новые задачи"
    
    // Связь с ролями через промежуточную таблицу
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
// Это промежуточная таблица для связи многие-ко-многим между Role и Permission
// У одной роли может быть много разрешений
// Одно разрешение может быть у многих ролей

namespace Task.net.Domain.Entities;

public class RolePermission
{
    // Composite primary key (составной первичный ключ из двух полей)
    public int RoleId { get; set; } // ID роли
    public Role Role { get; set; } = null!; // Навигационное свойство к роли
    
    public int PermissionId { get; set; } // ID разрешения
    public Permission Permission { get; set; } = null!; // Навигационное свойство к разрешению
}
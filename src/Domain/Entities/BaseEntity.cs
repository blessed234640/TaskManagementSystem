// BaseEntity - это базовый (родительский) класс для всех таблиц в БД
// Все общие поля выносятся сюда, чтобы не дублировать код

namespace Task.net.Domain.Entities;

// abstract - значит этот класс нельзя создать напрямую, только наследовать
public abstract class BaseEntity
{
    // Id - первичный ключ в базе данных (уникальный идентификатор записи)
    // public - доступно отовсюду
    // int - целое число (можно использовать Guid для распределенных систем)
    public int Id { get; set; }
    
    // DateTime - тип для даты и времени
    // { get; set; } - автоматические свойства (get - получить, set - установить)
    public DateTime CreatedAt { get; set; }
    
    // DateTime? - вопросительный знак значит, что может быть null (не заполнено)
    public DateTime? UpdatedAt { get; set; }
    
    // bool - логическое значение (true/false)
    // = true - значение по умолчанию при создании
    public bool IsActive { get; set; } = true; // Для мягкого удаления
}
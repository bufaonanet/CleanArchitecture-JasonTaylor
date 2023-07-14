using Domain.Common;
using Domain.Events;

namespace Domain.Entities;

public class TodoItem : AuditableEntity, IHasDomainEvent
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public DateTime? Reminder { get; set; }


    private bool _done;

    public bool Done
    {
        get => _done;
        set
        {
            if (value == true && _done == false)
            {
                DomainEvents.Add(new TodoItemCompletedEvent(this));
            }

            _done = value;
        }
    }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    
    public TodoList List { get; set; } = null!;
}
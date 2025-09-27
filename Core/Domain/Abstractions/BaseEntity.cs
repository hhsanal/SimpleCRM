namespace Domain.Abstractions;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
    }
    public Guid Id { get; set; }
    public Guid CreatedUserId { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public Guid UpdatedUserId { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
    public DateTimeOffset? DeleteAt { get; set; }
    public Guid? DeleteUserId { get; set; }
    public bool Status { get; set; }
}

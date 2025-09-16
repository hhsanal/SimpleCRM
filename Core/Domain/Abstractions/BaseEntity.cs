namespace Domain.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public int CreatedUserId { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public int UpdatedUserId { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
    public DateTimeOffset? DeleteAt { get; set; }
    public int? DeleteUserId { get; set; }
    public bool Status { get; set; }
}

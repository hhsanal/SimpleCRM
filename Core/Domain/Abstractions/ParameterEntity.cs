namespace Domain.Abstractions;

public abstract class ParameterEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

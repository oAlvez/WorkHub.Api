namespace WorkHub.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; }
    public Guid CreateUserId { get; set; }
    public Guid UpdateUserId { get; set; }
}

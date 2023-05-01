using Chat.DAL.Contracts;

namespace Chat.DAL.Entities;

public class BaseEntity : IBaseEntity
{
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
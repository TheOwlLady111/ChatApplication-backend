using Chat.DAL.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Chat.DAL.Entities;

public class User : IdentityUser<int>, IBaseEntity
{
    public ICollection<Message> Messages { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
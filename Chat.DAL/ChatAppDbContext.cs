using Chat.DAL.Configurations;
using Chat.DAL.Contracts;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL;

public class ChatAppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageConfiguration).Assembly);
    }
}

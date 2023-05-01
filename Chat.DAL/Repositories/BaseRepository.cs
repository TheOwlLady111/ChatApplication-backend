using Chat.DAL.Contracts;
using Chat.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ChatAppDbContext _applicationContext;
    protected readonly DbSet<T> DbSet;

    protected BaseRepository(ChatAppDbContext applicationContext)
    {
        _applicationContext = applicationContext;
        DbSet = _applicationContext.Set<T>();
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        var createdEntity = await DbSet.AddAsync(entity);

        return createdEntity.Entity;
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public Task SaveChanges(CancellationToken token)
    {
        var entries = _applicationContext.ChangeTracker.Entries<IBaseEntity>();
        foreach (var entityEntry in entries)
        {
            var entity = entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedAtUtc = DateTime.Now;

                    break;

                case EntityState.Modified:
                    entity.UpdatedAtUtc = DateTime.Now;

                    break;
            }
        }

        return _applicationContext.SaveChangesAsync(token);
    }
}
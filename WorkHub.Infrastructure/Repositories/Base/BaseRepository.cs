using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorkHub.Application.Extensions;
using WorkHub.Application.Interfaces.Repositories.Base;
using WorkHub.Domain.Entities.Base;
using WorkHub.Exceptions;
using WorkHub.Infrastructure.Context;
using WorkHub.Infrastructure.Handlers;

namespace WorkHub.Infrastructure.Repositories.Base;
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DatabaseContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DatabaseContext dbContext) { 
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().Where(x => !x.Deleted).ToListAsync();
    }
    public async Task<T> GetByIdAsync(Guid id)
    {
        ValidateEntityId(id);
        var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return entity ?? throw new NotFoundException(ResourceDatabaseErrorMessages.RECORD_WAS_NOT_FOUND);
    }
    public async Task<bool> InsertAsync(T entity)
    {
        ValidateEntityId(entity.Id);

        entity.Deleted = false;
        entity.CreateAt = DateTime.UtcNow.UtcToTimeZone();

        await _dbSet.AddAsync(entity);
        return await CommitChangesAsync();
    }
    public async Task<bool> UpdateAsync(T entity)
    {
        ValidateEntityId(entity.Id);

        var exists = await _dbSet.AsNoTracking().AnyAsync(x => x.Id == entity.Id);

        if (!exists)
            throw new NotFoundException(ResourceDatabaseErrorMessages.RECORD_WAS_NOT_FOUND);

        entity.UpdateAt = DateTime.UtcNow.UtcToTimeZone();

        _dbContext.Entry(entity).State = EntityState.Modified;
        return await CommitChangesAsync();
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        ValidateEntityId(id);

        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            throw new NotFoundException(ResourceDatabaseErrorMessages.RECORD_WAS_NOT_FOUND);

        entity.Deleted = true;
        entity.UpdateAt = DateTime.UtcNow.UtcToTimeZone();

        _dbContext.Entry(entity).State = EntityState.Modified;
        return await CommitChangesAsync();
    }
    private static void ValidateEntityId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ErrorOnValidationException(ResourceDatabaseErrorMessages.ENTITY_ID_IS_NULL);
    }
    private async Task<bool> CommitChangesAsync()
    {
        try
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException dbEx)
        {
            DataBaseExceptionHandler.Throw(dbEx);
            return false;
        }
        catch (SqlException)
        {
            throw new DatabaseException(ResourceDatabaseErrorMessages.UNABLE_TO_ACCESS_DATABASE);
        }
    }
}
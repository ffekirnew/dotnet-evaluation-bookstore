using Microsoft.EntityFrameworkCore;
using Application.Contracts.Persistence.Repositories;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
  private readonly DbContext _dbContext;

  public GenericRepository(DbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<T> CreateAsync(T entity)
  {
    await _dbContext.AddAsync(entity);
    return entity;
  }

  public async Task DeleteAsync(T entity)
  {
    _dbContext.Set<T>().Remove(entity);
    return;
  }

  public async Task<bool> Exists(int id)
  {
    var entity = await GetAsync(id);
    return entity != null;
  }

  public async Task<T> GetAsync(int id)
  {
    var entity = await _dbContext.Set<T>().FindAsync(id);
    return entity!;
  }

  public async Task UpdateAsync(T entity)
  {
    _dbContext.Entry(entity).State = EntityState.Modified;
  }

  public async Task<List<T>> GetAsync()
  {
    return await _dbContext.Set<T>().ToListAsync();
  }
}

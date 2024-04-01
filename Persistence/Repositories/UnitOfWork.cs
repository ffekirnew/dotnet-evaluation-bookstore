using Application.Contracts.Persistence.Repositories;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
  private readonly AppDbContext _dbContext;
  private BookRepository? _bookRepository;


  public UnitOfWork(AppDbContext dbContext) => _dbContext = dbContext;

  public IBookRepository BookRepository
  {
    get => _bookRepository ??= new BookRepository(_dbContext);
  }


  public async Task<int> SaveAsync()
  {
    return await _dbContext.SaveChangesAsync();
  }

  public void Dispose()
  {
    _dbContext.Dispose();
    GC.SuppressFinalize(this);
  }
}

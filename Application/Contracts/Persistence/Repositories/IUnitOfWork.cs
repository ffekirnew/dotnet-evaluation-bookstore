namespace Application.Contracts.Persistence.Repositories;

public interface IUnitOfWork : IDisposable
{
  IBookRepository BookRepository { get; }

  Task<int> SaveAsync();
}

using Application.Contracts.Persistence.Repositories;
using Domain.Entities;

namespace Persistence.Repositories;

public class BookRepository : GenericRepository<BookEntity>, IBookRepository
{
  private readonly AppDbContext _context;

  public BookRepository(AppDbContext context)
      : base(context)
  {
    _context = context;
  }
}

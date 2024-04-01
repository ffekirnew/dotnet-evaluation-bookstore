using Application.Common.Responses;
using Application.Contracts.Persistence.Repositories;
using Application.Features.Book.Dtos;
using Application.Features.Book.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Handlers.Queries;

public class SearchBookQueryHandler : IRequestHandler<SearchBooksQuery, BaseResponse<List<BookDto>>>
{
  private IUnitOfWork _unitOfWork;
  private IMapper _mapper;
  public SearchBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<BaseResponse<List<BookDto>>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
  {
    var books = await _unitOfWork.BookRepository.GetAsync();

    var response = BaseResponse<List<BookDto>>.Success(
        _mapper.Map<List<BookDto>>(
            books.Where(book =>
                book.Title.Contains(request.SearchKey) ||
                book.Author.Contains(request.SearchKey) ||
                book.Description.Contains(request.SearchKey)
            )
        )
    );

    return response;
  }
}

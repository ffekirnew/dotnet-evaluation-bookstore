using MediatR;
using Application.Common.Responses;
using Application.Features.Book.Dtos;

namespace Application.Features.Book.Requests.Queries;
public class SearchBooksQuery : IRequest<BaseResponse<List<BookDto>>>
{
  public string? SearchKey { get; set; }
}

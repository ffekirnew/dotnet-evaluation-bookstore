using MediatR;
using Application.Common.Responses;
using Application.Features.Book.Dtos;

namespace Application.Features.Book.Requests.Queries;
public class GetBookQuery : IRequest<BaseResponse<BookDto>>
{
  public int Id { get; set; }
}

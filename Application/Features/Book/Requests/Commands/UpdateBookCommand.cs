namespace Application.Features.Book.Requests.Commands;

using MediatR;

using Application.Features.Book.Dtos;
using Application.Common.Responses;

public class UpdateBookCommand : IRequest<BaseResponse<BookDto>>
{
  public UpdateBookDto UpdateBookDto { get; set; } = null!;
}

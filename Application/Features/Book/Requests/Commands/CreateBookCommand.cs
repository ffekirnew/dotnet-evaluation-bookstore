namespace Application.Features.Book.Requests.Commands;

using MediatR;

using Application.Features.Book.Dtos;
using Application.Common.Responses;

public class CreateBookCommand : IRequest<BaseResponse<BookDto>>
{
  public CreateBookDto CreateBookDto { get; set; } = null!;
}

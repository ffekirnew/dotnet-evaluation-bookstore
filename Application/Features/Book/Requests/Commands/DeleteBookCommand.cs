using Application.Common.Responses;
using MediatR;

namespace Application.Features.Book.Requests.Commands;

public class DeleteBookCommand : IRequest<BaseResponse<Unit>>
{
  public int Id { get; set; }
}

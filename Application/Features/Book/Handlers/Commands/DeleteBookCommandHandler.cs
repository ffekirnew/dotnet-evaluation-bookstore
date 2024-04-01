using Application.Common.Responses;
using Application.Contracts.Persistence.Repositories;
using Application.Features.Book.Requests.Commands;
using AutoMapper;
using MediatR;


namespace SocialSync.Application.Features.Books.Handlers.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BaseResponse<Unit>>
{

  private IUnitOfWork _unitOfWork;

  public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;

  }

  public async Task<BaseResponse<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
  {

    var post = await _unitOfWork.BookRepository.GetAsync(request.Id);
    await _unitOfWork.BookRepository.DeleteAsync(post);

    var success = await _unitOfWork.SaveAsync();
    if (success == 0)
    {
      return BaseResponse<Unit>.Failure("Error deleting book");
    }

    return BaseResponse<Unit>.Success(Unit.Value);
  }
}

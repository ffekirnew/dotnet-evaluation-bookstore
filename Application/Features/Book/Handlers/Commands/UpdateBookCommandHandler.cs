using AutoMapper;
using MediatR;

using Domain.Entities;
using Application.Features.Book.Dtos.Validators;
using Application.Features.Book.Requests.Commands;
using Application.Contracts.Persistence.Repositories;
using Application.Common.Exceptions;
using Application.Features.Book.Dtos;
using Application.Common.Responses;

namespace Application.Features.Book.Handlers.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseResponse<BookDto>>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<BaseResponse<BookDto>> Handle(
      UpdateBookCommand request,
      CancellationToken cancellationToken
  )
  {
    var dtoValidator = new UpdateBookDtoValidator();
    var validationResult = dtoValidator.Validate(request.UpdateBookDto);

    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult);
    }

    var book = _mapper.Map<BookEntity>(request.UpdateBookDto);
    await _unitOfWork.BookRepository.UpdateAsync(book);

    var success = await _unitOfWork.SaveAsync();

    if (success == 0)
    {
      return BaseResponse<BookDto>.Failure("Error updating book");
    }

    var response = BaseResponse<BookDto>.Success(_mapper.Map<BookDto>(book));

    return response;
  }
}

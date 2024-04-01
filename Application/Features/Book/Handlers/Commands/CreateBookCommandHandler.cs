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

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseResponse<BookDto>>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<BaseResponse<BookDto>> Handle(
      CreateBookCommand request,
      CancellationToken cancellationToken
  )
  {
    var dtoValidator = new CreateBookDtoValidator();
    var validationResult = dtoValidator.Validate(request.CreateBookDto);

    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult);
    }

    var book = _mapper.Map<BookEntity>(request.CreateBookDto);
    book = await _unitOfWork.BookRepository.CreateAsync(book);
    var success = await _unitOfWork.SaveAsync();

    if (success == 0)
    {
      return BaseResponse<BookDto>.Failure("Error creating book");
    }

    var response = BaseResponse<BookDto>.Success(_mapper.Map<BookDto>(book));

    return response;
  }
}

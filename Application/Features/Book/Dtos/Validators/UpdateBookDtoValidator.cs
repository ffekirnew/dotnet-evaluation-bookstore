using Application.Features.Book.Dtos;
using FluentValidation;

namespace Application.Features.Book.Dtos.Validators;

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
  public UpdateBookDtoValidator()
  {
    Include(new BookDtoValidator());
  }
}

using Application.Features.Book.Dtos;
using FluentValidation;

namespace Application.Features.Book.Dtos.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
  public CreateBookDtoValidator()
  {
    Include(new BookDtoValidator());
  }
}

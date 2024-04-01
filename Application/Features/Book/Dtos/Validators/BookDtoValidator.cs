namespace Application.Features.Book.Dtos.Validators;

using FluentValidation;
using Application.Features.Book.Dtos;

public class BookDtoValidator : AbstractValidator<IBookDto>
{
  public BookDtoValidator()
  {
    RuleFor(u => u.Title)
        .NotEmpty()
        .WithMessage("{PropertyName} is required.")
        .MaximumLength(20)
        .WithMessage("{PropertyName} must not exceed 20 characters.")
        .MinimumLength(3)
        .WithMessage("{PropertyName} must be at least 3 characters.");

    RuleFor(u => u.Author)
        .NotEmpty()
        .WithMessage("{PropertyName} is required.")
        .MaximumLength(15)
        .WithMessage("{PropertyName} must not exceed 15 characters.")
        .MinimumLength(6)
        .WithMessage("{PropertyName} must be at least 6 characters.");

    RuleFor(u => u.Description)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} must not exceed 50 characters.")
            .MinimumLength(6)
            .WithMessage("{PropertyName} must be at least 6 characters.");
  }
}

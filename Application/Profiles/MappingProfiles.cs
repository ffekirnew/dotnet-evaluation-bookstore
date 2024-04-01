using Application.Features.Book.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    #region BlogPost Mappings
    CreateMap<BookEntity, BookDto>();
    CreateMap<BookEntity, CreateBookDto>();
    CreateMap<BookEntity, UpdateBookDto>();

    CreateMap<CreateBookDto, BookEntity>();
    CreateMap<UpdateBookDto, BookEntity>();
    #endregion
  }
}

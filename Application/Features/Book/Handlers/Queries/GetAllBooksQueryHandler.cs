using Application.Common.Responses;
using Application.Contracts.Persistence.Repositories;
using Application.Features.Book.Dtos;
using Application.Features.Book.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Features.Book.Handlers.Queries;


public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, BaseResponse<List<BookDto>>>
{
  private IUnitOfWork _unitOfWork;
  private IMapper _mapper;
  public GetAllBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<BaseResponse<List<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
  {
    BaseResponse<List<BookDto>> response;
    response = BaseResponse<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(await _unitOfWork.BookRepository.GetAsync()));
    return response;
  }
}

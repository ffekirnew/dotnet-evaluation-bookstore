using Application.Common.Responses;
using Application.Contracts.Persistence.Repositories;
using Application.Features.Book.Dtos;
using Application.Features.Book.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Handlers.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BaseResponse<BookDto>>
{
  private IUnitOfWork _unitOfWork;
  private IMapper _mapper;
  public GetBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<BaseResponse<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
  {
    var post = await _unitOfWork.BookRepository.GetAsync(request.Id);
    var response = BaseResponse<BookDto>.Success(_mapper.Map<BookDto>(post));
    return response;
  }
}

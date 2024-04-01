using MediatR;
using Application.Common.Responses;
using Application.Features.Book.Dtos;

namespace Application.Features.Book.Requests.Queries;
public class GetAllBooksQuery : IRequest<BaseResponse<List<BookDto>>>
{
}

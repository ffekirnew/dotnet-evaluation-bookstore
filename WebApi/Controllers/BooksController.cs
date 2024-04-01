using MediatR;
using Application.Features.Book.Requests.Queries;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Book.Dtos;
using Application.Features.Book.Requests.Commands;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
      Console.WriteLine("here");
      var getAllRequest = new GetAllBooksQuery();
      var response = await _mediator.Send(getAllRequest);
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var getBookByIdRequest = new GetBookQuery { Id = id };
      var response = await _mediator.Send(getBookByIdRequest);
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDto createBookDto)
    {
      var createCommand = new CreateBookCommand { CreateBookDto = createBookDto };
      var response = await _mediator.Send(createCommand);
      if (response.IsSuccess)
      {
        return CreatedAtAction(nameof(Get), new { id = response }, response);
      }
      else
      {
        return BadRequest(response);
      }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto updateBookDto)
    {
      var updateCommand = new UpdateBookCommand { UpdateBookDto = updateBookDto };
      var response = await _mediator.Send(updateCommand);

      if (response.IsSuccess)
      {
        return Ok(response);
      }
      else
      {
        return BadRequest(response);
      }
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var deleteBookCommand = new DeleteBookCommand { Id = id };
      var response = await _mediator.Send(deleteBookCommand);
      if (response.IsSuccess)
      {
        return Ok(response);
      }
      else
      {
        return BadRequest(response);
      }
    }
  }
}

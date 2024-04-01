namespace Application.Features.Book.Dtos;

public class IBookDto
{
  public string? Title { get; set; }
  public string? Author { get; set; }
  public string? Description { get; set; }
  public string? Category { get; set; }
  public string? Language { get; set; }
  public int TotalPages { get; set; }
}


namespace Johoot.Workshop.Api.DataDto
{
  public class AnswerDto
  {
    public long Id { get; set; }
    public string Text { get; set; }
    public bool? IsCorrect { get; set; }
  }
}
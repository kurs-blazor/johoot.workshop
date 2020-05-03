namespace Johoot.Workshop.Api.DataDto
{
  public class QuestionDto
  {
    public long Id { get; set; }
    public long QuizeId { get; set; }

    public int TimeLimitSeconds { get; set; }
    public string Text { get; set; }
    public int Points { get; set; }

    public bool HasCorrectAnswer { get; set; }
    public bool IsOpenQuestion { get; set; }

    public string ImageUri { get; set; }
  }
}
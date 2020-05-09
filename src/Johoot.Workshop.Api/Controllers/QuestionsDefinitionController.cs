using Johoot.Data;
using Johoot.Workshop.Api.DataDto;
using Johoot.Workshop.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class QuestionsDefinitionController : ControllerBase
  {
    private readonly ILogger<QuestionsDefinitionController> _logger;
    private readonly IQuestionRepository _repository;

    public QuestionsDefinitionController(
        ILogger<QuestionsDefinitionController> logger,
        IQuestionRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Question>>> GetAll()
    {
      return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> Get(long id)
    {
      return Ok(await _repository.FindById(id));
    }

    [HttpGet("find/{quizeId}")]
    public async Task<ActionResult<List<Question>>> FilterByQuize(long quizeId, bool includeAll = true)
    {
      return Ok(await _repository.FindByQuizeId(quizeId, includeAll));
    }


    [HttpPost]
    public async Task<ActionResult<Question>> Create(QuestionDto item)
    {
      //new question object 
      var nq = new Question
      {
        HasCorrectAnswer = item.HasCorrectAnswer,
        IsOpenQuestion = item.IsOpenQuestion,
        Points = item.Points,
        Text = item.Text,
        TimeLimitSeconds = item.TimeLimitSeconds
      };
      var created = await _repository.Create(nq, item.QuizeId);
      return CreatedAtAction(
          nameof(this.Get),
          new { id = created.Id },
          created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, QuestionDto item)
    {
      if (id != item?.Id)
      {
        return BadRequest();
      }

      var nq = new Question
      {
        HasCorrectAnswer = item.HasCorrectAnswer,
        IsOpenQuestion = item.IsOpenQuestion,
        Points = item.Points,
        Text = item.Text,
        TimeLimitSeconds = item.TimeLimitSeconds,
        Id = item.Id
      };

      var updated = await _repository.Update(nq, id);
      if (updated == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}

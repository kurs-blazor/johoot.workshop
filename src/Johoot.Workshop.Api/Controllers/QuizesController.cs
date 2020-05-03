﻿using Johoot.Data;
using Johoot.Workshop.Api.DataDto;
using Johoot.Workshop.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Api.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class QuizesController : ControllerBase
  {
    private readonly IQuizesRepository _quizesRepository;
    public QuizesController(IQuizesRepository quizesRepository)
    {
      _quizesRepository = quizesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Quize>>> GetAll(bool includeAll = true)
    {
      return Ok(await _quizesRepository.GetAll(includeAll));
    }

    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<Quize>> Get(long id)
    {
      return Ok(await _quizesRepository.FindById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Quize>> Post([FromBody] QuizeDto item)
    {
      var q = new Quize
      {
        Id = item.Id,
        Description = item.Description,
        Name = item.Name
      };
      var created = await _quizesRepository.Create(q);

      return CreatedAtAction(
        nameof(this.Get),
        new { id = created.Id },
        created);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] QuizeDto item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      var uq = new Quize
      {
        Id = item.Id,
        Description = item.Description,
        Name = item.Name
      };

      var updated = await _quizesRepository.Update(id, uq);
      if (updated == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}

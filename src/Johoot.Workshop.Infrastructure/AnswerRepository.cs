using Johoot.Data;
using Johoot.Workshop.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Johoot.Workshop.Infrastructure
{
  public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
  {
    private readonly JohootWorkshopContext _joContext;

    public AnswerRepository(JohootWorkshopContext context) : base(context)
    {
      _joContext = context;
    }

    public async Task<Answer> Create(Answer item, long questionId)
    {
      item.Question = await _joContext.Questions.FindAsync(questionId);
      return await base.AddAsyn(item);
    }

    public async Task<Answer> FindById(long id)
    {
      return await base.FindAsync(q => q.Id == id);
    }

    public async Task<Answer> Update(Answer item, long id)
    {
      return await base.UpdateAsync(item, id);
    }

    public async Task<ICollection<Answer>> GetAll()
    {
      return await base.GetAllAsync();
    }

    public async Task<IList<Answer>> FindByQuestionId(long questionId)
    {
      return await _joContext.Answers
           .Where(q => q.Question.Id == questionId)
           .ToListAsync();
    }
  }
}

using Johoot.Data;
using Johoot.Workshop.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Infrastructure
{
  public class AnswerRepository : IAnswerRepository
  {
    public Task<Answer> Create(Answer item, long questionId)
    {
      throw new NotImplementedException();
    }

    public Task<Answer> FindById(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Answer>> FindByQuestionId(long questionId)
    {
      throw new NotImplementedException();
    }

    public Task<ICollection<Answer>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<Answer> Update(Answer item, long id)
    {
      throw new NotImplementedException();
    }
  }
}

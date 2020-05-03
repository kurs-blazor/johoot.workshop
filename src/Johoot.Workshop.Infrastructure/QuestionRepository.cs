using Johoot.Data;
using Johoot.Workshop.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Infrastructure
{
  public class QuestionRepository : IQuestionRepository
  {
    public Task<Question> Create(Question item, long quizeId)
    {
      throw new NotImplementedException();
    }

    public Task<Question> FindById(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Question>> FindByQuizeId(long quizeId, bool includeAll = true)
    {
      throw new NotImplementedException();
    }

    public Task<ICollection<Question>> GetAll(bool includeAll = true)
    {
      throw new NotImplementedException();
    }

    public Task<Question> Update(Question item, long id)
    {
      throw new NotImplementedException();
    }
  }
}

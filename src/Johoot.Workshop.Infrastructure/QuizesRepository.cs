using Johoot.Data;
using Johoot.Workshop.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Infrastructure
{
  public class QuizesRepository : IQuizesRepository
  {
    public Task<Quize> Create(Quize q)
    {
      throw new NotImplementedException();
    }

    public Task<Quize> FindById(long id, bool includeAll = true)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Quize>> GetAll(bool includeAll = true)
    {
      throw new NotImplementedException();
    }

    public Task<Quize> Update(long id, Quize q)
    {
      throw new NotImplementedException();
    }
  }
}

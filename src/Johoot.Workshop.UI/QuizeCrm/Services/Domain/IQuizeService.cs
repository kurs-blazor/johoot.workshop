using Johoot.Data;
using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.UI.QuizeCrm.Services
{
  public interface IQuizeService
  {
    Task<Quize> Create(Quize item);
    Task<IList<Quize>> GetAll(bool includeAll = true);
    Task<Quize> GetById(long id);
    Task Update(QuizeViewModel item);
  }
}
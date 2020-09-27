using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.UI.QuizeCrm.Services
{
  public interface IQuizeService
  {
    Task<QuizeViewModel> Create(QuizeViewModel item);
    Task<IList<QuizeViewModel>> GetAll(bool includeAll = true);
    Task<QuizeViewModel> GetById(long id);
    Task Update(QuizeViewModel item);
  }
}
using AutoMapper;
using Johoot.Data;
using Johoot.Workshop.UI.QuizeCrm.ViewModels;

namespace Johoot.Workshop.Configs
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<Quize, QuizeViewModel>().ReverseMap();
    }
  }
}

using Johoot.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Johoot.Workshop.UI.Pages
{
  public class QuizeOverviewBase : ComponentBase
  {
    public IList<Quize> Quizes { get; set; }
    protected override void OnInitialized()
    {
      base.OnInitialized();
      Quizes = new List<Quize> {
        new Quize {
          Description= "Simulated quize description",
          Id =1,
          Name = "First Quize"}
      };
    }
  }
}

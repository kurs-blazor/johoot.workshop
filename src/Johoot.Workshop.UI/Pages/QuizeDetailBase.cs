using Johoot.Data;
using Microsoft.AspNetCore.Components;

namespace Johoot.Workshop.UI.Pages
{
  public class QuizeDetailBase : ComponentBase
  {
    [Parameter]
    public int QuizeId { get; set; }
    public Quize Quize { get; set; } = new Quize();

    protected override void OnInitialized()
    {
      base.OnInitialized();
      Quize = new Quize
      {
        Description = "Simulated quize description",
        Id = 1,
        Name = "First Quize"
      };
    }
  }
}

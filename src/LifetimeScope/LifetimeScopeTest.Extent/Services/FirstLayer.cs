using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class FirstLayer : BaseService, IFirstLayer
  {

    public List<string> AllInstanceNames
    {
      get
      {
        return new List<string>
        {
          InstanceName
        };
      }
    }
  }
}

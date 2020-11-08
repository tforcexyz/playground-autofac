using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IBaseContract
  {

    List<string> AllInstanceNames { get; }

    string InstanceName { get; }
  }
}

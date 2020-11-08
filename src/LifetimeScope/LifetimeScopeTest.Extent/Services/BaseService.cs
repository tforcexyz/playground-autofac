using System;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public abstract class BaseService
  {

    private readonly Guid _instanceId;

    public BaseService()
    {
      _instanceId = Guid.NewGuid();
    }

    public string InstanceName
    {
      get
      {
        return $"@{GetType().Name}: @{_instanceId}";
      }
    }
  }
}

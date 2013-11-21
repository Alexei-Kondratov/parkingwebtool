using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace ParkingWebTool.Web.Common
{
    public class UnityDependencyResolver : UnityScopeContainer, IDependencyResolver
    {
        public UnityDependencyResolver(IUnityContainer container) : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityScopeContainer(child);
        }
    }
}

using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace ParkingWebTool.Web.Common
{
    public class UnityScopeContainer : IDependencyScope
    {
        protected IUnityContainer container;

        public UnityScopeContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}

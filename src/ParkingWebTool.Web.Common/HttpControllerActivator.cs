using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ParkingWebTool.Web.Common
{
    public class HttpControllerActivator : IHttpControllerActivator
    {
        private IUnityContainer mContainer;
        public HttpControllerActivator(IUnityContainer container)
        {
            mContainer = container;
        }
        public IHttpController Create(HttpControllerContext controllerContext, Type controllerType)
        {
            return (IHttpController)mContainer.Resolve(controllerType);
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)mContainer.Resolve(controllerType);
        }
    }
}

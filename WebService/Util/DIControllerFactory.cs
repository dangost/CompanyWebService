using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace WebService.Util
{
    public class DIControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer _container;
        public DIControllerFactory(IUnityContainer c) => _container = c;
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return _container.Resolve(controllerType) as Controller;
        }
    }
}
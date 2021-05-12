using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;

namespace CanturkFramework.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(params INinjectModule[] module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(
                404, String.Format(
                "The controller for path '{0}' could not be found " +
                "or it does not implement IController.",
                requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Get(controllerType);
        }
    }
}

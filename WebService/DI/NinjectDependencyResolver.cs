using Ninject;
using System.Web.Http.Dependencies;
using WebService.DI;

namespace WebService.DI
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}
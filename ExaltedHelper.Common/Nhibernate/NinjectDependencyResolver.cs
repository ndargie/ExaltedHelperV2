﻿using System.Web.Http.Dependencies;
using Ninject;

namespace ExaltedHelper.Common.Nhibernate
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel.BeginBlock());
        }
    }
}
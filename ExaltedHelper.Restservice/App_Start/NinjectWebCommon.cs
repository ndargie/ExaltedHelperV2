
using System;
using System.Web.Http;
using ExaltedHelper.Common.Nhibernate;
using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.DatabaseFactories.DatabaseFactories.Interfaces;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Managers.Time;
using ExaltedHelper.Managers.Time.Interface;
using ExaltedHelper.Repositories.Contracts;
using ExaltedHelper.Repositories.DatabaseFactories;
using ExaltedHelper.Repository.Repositories;
using ExaltedHelper.Repository.Seed;
using ExaltedHelper.Repository.Seed.Interface;
using ExaltedHelper.RestService;
using NHibernate;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(NinjectWebCommon), "RegisterNinject"),
           ApplicationShutdownMethod(typeof(NinjectWebCommon), "UnRegisterNinject")]
namespace ExaltedHelper.RestService
{
 
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static T GetConcreteImplementation<T>()
        {
            return Bootstrapper.Kernel.Get<T>();
        }

        public static void RegisterNinject()
        {
           Bootstrapper.Initialize(CreateKernel);
        }

        public static void UnRegisterNinject()
        {
            Bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISession>().ToMethod(item => item.Kernel.Get<IDatabaseFactory>().SessionFactory.OpenSession())
                .InRequestScope();
            kernel.Bind<IDatabaseFactory>().To<SqlServerDatabaseFactory>().InSingletonScope();
            kernel.Bind<IRepository<Duration, int>>().To<DurationRepository>().InRequestScope();
            kernel.Bind<IRepository<CraftType, int>>().To<CraftTypeRepository>().InRequestScope();
            kernel.Bind<IRepository<Charm, int>>().To<CharmRepository>().InRequestScope();
            kernel.Bind<IRepository<CharmType, int>>().To<CharmTypeRepository>().InRequestScope();
            kernel.Bind<IRepository<Keyword, int>>().To<KeywordRepository>().InRequestScope();
            kernel.Bind<IRepository<Skill, int>>().To<SkillRepository>().InRequestScope();
            kernel.Bind<ISeedParams>().To<SeedParams>().InRequestScope();
            kernel.Bind<ISeedManager>().To<SeedManager>().InRequestScope();
            kernel.Bind<IRepository<ExaltedType, int>>().To<ExaltedTypeRepository>().InRequestScope();
            kernel.Bind<IRepository<Caste, int>>().To<CasteRepository>().InRequestScope();
            kernel.Bind<IRepository<Functionality, int>>().To<FunctionalityRepository>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IDurationManager>().To<DurationManager>().InRequestScope();
        }
    }
}
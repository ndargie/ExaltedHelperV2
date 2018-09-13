using System;
using System.Configuration;
using System.IO;
using ExaltedHelper.DatabaseFactories.DatabaseFactories;
using ExaltedHelper.DatabaseFactories.DatabaseFactories.Extensions;
using ExaltedHelper.DatabaseFactories.DatabaseFactories.Interfaces;
using ExaltedHelper.Domain.Base;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ExaltedHelper.Repositories.DatabaseFactories
{
    public class SqlServerDatabaseFactory : IDatabaseFactory, IDisposable
    {
        private readonly string _hibernateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config");
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExaltedConnectionString"].ConnectionString;
        private readonly ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory => _sessionFactory;

        public void Dispose()
        {
            SessionFactory?.Dispose();
        }

        public SqlServerDatabaseFactory()
        {
            var assembly = typeof(EntityBase).Assembly;
            var fileCache = new ConfigurationFileCache(assembly, _hibernateFilePath);
            var config = fileCache .LoadConfigurationFromFile();
            if (config == null)
            {
                var mapping = AutoMap.AssemblyOf<EntityBase>(new MappingConfiguration())
                    .UseOverridesFromAssemblyOf<MappingConfiguration>();
                _sessionFactory =
                    Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString)
                            .ShowSql())
                        .Mappings(m => m.AutoMappings.Add(mapping))
                        .ExposeConfiguration(c => c.BuildSchema(NhibernateExtensions.RecreateSchema()))
                        .ExposeConfiguration(fileCache.SaveConfigurationToFile)
                        .BuildSessionFactory();
                config = fileCache.LoadConfigurationFromFile();
                _sessionFactory = config.BuildSessionFactory();
            }
            else
            {
                _sessionFactory = config.BuildSessionFactory();
            }
        }
    }
}
using NHibernate;

namespace ExaltedHelper.DatabaseFactories.DatabaseFactories.Interfaces
{
    public interface IDatabaseFactory
    {
        ISessionFactory SessionFactory { get; }
    }
}
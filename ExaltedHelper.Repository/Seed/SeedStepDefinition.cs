using System;
using Tamarack.Pipeline;

namespace ExaltedHelper.Repository.Seed
{
    public abstract class SeedStepDefinition : IFilter<DatabaseInitializer, bool>
    {
        public bool Execute(DatabaseInitializer context, Func<DatabaseInitializer, bool> executeNext)
        {
            using (var tx = context.Session.BeginTransaction())
            {
                ExecuteStep(ref context);

                context.Session.Flush();
                tx.Commit();
            }

            return executeNext(context);
        }

        protected abstract void ExecuteStep(ref DatabaseInitializer context);
    }
}
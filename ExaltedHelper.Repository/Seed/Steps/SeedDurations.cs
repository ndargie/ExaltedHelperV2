using System.Collections.Generic;
using ExaltedHelper.Domain.Entities;

namespace ExaltedHelper.Repository.Seed.Steps
{
    public class SeedDurations : SeedStepDefinition
    {
        protected override void ExecuteStep(ref DatabaseInitializer context)
        {
            List<Duration> durations = new List<Duration>
            {
                new Duration() {Name = "N/A", Description = "Not applicable"},
                new Duration() {Name = "Varies", Description = "See charm description"},
                new Duration() {Name = "Instant", Description = "Charm goes off straight away"},
                new Duration() {Name = "One action", Description = "Last for a single action"},
                new Duration() {Name = "Until next action", Description = "Until next action"},
                new Duration() {Name = "One scene", Description = "Charm lasts one scene"},
                new Duration() {Name = "One week", Description = "One week"},
                new Duration() {Name = "Indefinite", Description = "Charm lasts forever"}
            };

            foreach (var duration in durations)
            {
                context.DurationRepository.Save(duration);
            }

        }
    }
}
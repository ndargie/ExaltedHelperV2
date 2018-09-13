using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaltedHelper.Repository.Seed
{

    public enum StepDefinition
    {
        Durations,
        CraftTypes,
        Skills,
        Keyworks,
        CharmTypes
    }

    public class SeedFactory
    {
        private const string NamespacePrefix = "ExaltedHelper.Repository.Seed.Steps";

        public static IList<SeedStepDefinition> CreateStepDefinitions()
        {
            string[] stepDefinitionsNames = Enum.GetNames(typeof(StepDefinition));

            return (from stepDefinitionsName in stepDefinitionsNames
                select Type.GetType(NamespacePrefix + ".Seed" + stepDefinitionsName)
                into currentType
                where currentType != null
                select (SeedStepDefinition)Activator.CreateInstance(currentType)).ToList();
        }
    }
}
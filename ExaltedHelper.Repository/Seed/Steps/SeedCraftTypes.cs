using System.Collections.Generic;
using ExaltedHelper.Domain.Entities;

namespace ExaltedHelper.Repository.Seed.Steps
{
    public class SeedCraftTypes : SeedStepDefinition
    {
        protected override void ExecuteStep(ref DatabaseInitializer context)
        {
            List<CraftType> craftTypes = new List<CraftType>()
            {
                new CraftType()
                {
                    Name = "Air",
                    Description = "Calligraphy, small precision or decorative items",
                    Mundane = true
                },
                new CraftType()
                {
                    Name = "Earth",
                    Description = "Masonry, buildings, large earth/stonework",
                    Mundane = true
                },
                new CraftType()
                {
                    Name = "Fire",
                    Description = "Blacksmithing, ceramics, forging and creating items with fire"
                },
                new CraftType()
                {
                    Name = "Wood",
                    Description = "Carpentry, weaving, flower-arranging, working with natural materials",
                    Mundane = true
                },
                new CraftType()
                {
                    Name = "Water",
                    Description = "Cooking, brewing, leatherwork, pharmacy, poison-working",
                    Mundane = true
                },
                new CraftType()
                {
                    Name = "Magitech",
                    Description =
                        "Allows understanding First Age artifacts, the ability to repair broken Magitech, and the potential to build new Magitech.",
                    Mundane = false
                }
            };
            foreach (var craftType in craftTypes)
            {
                context.CraftTypeRepository.Save(craftType);
            }
        }
    }
}
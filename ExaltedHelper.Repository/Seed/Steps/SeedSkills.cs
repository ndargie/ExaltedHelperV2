using System.Collections.Generic;
using System.Linq;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;

namespace ExaltedHelper.Repository.Seed.Steps
{
    public class SeedSkills : SeedStepDefinition
    {
        protected override void ExecuteStep(ref DatabaseInitializer context)
        {
            var exaltedType = new ExaltedType() {Name = "Solar", Description = "Chosen of the unconquered sun"};
            var solar = context.ExaltedTypeRepository.Save(exaltedType);
            
            IList<Caste> castes = new List<Caste>()
            {
                new Caste() {Name = "Dawn", Description = "Warriors and generals", ExaltedType = solar},
                new Caste() {Name = "Zenith", Description = "Religious leaders", ExaltedType = solar},
                new Caste() {Name = "Twlight", Description = "Sorcers and loremasters", ExaltedType = solar},
                new Caste() {Name = "Night", Description = "Assasins, spies and thieves", ExaltedType = solar},
                new Caste() {Name = "Eclipse", Description = "Diplomats", ExaltedType = solar}
            };

            IList<Caste> savedCastes = new List<Caste>();

            foreach (var caste in castes)
            {
                savedCastes.Add(context.CasteRepository.Save(caste));
            }

            List<Skill> skills = new List<Skill>()
            {
                new Skill()
                {
                    Name = "Archery",
                    Description = "Skill for ranged combat",
                    Caste = savedCastes.Single(x => x.Name == "Dawn")
                },
                new Skill()
                {
                    Name = "Athletics",
                    Description = "Skill for performaing feats of strength and acrobatic",
                    Caste = savedCastes.Single(x => x.Name == "Night")
                },
                new Skill()
                {
                    Name = "Brawl",
                    Description = "Informal unarmed fighting",
                    Caste = savedCastes.Single(x => x.Name == "Dawn")
                },
                new Skill()
                {
                    Name = "Bureaucracy",
                    Description = "Managing large organisation and navigating formal processes",
                    Caste = savedCastes.Single(x => x.Name == "Eclipse")
                },
                new Skill()
                {
                    Name = "Craft",
                    Description = "User to create goods, manage craft projects",
                    Caste = savedCastes.Single(x => x.Name == "Twlight")
                },
                new Skill()
                {
                    Name = "Dodgy",
                    Description = "Dodge incomming attacks",
                    Caste = savedCastes.Single(x => x.Name == "Night")
                },
                new Skill()
                {
                    Name = "Integrity",
                    Description = "Ability to withstand mental influence",
                    Caste = savedCastes.Single(x => x.Name == "Zenith")
                },
                new Skill()
                {
                    Name = "Investigation",
                    Description = "Locate clues and investigate areas",
                    Caste = savedCastes.Single(x => x.Name == "Twlight")
                },
                new Skill()
                {
                    Name = "Larceny",
                    Description = "Dealing with criminal activity",
                    Caste = savedCastes.Single(x => x.Name == "Night")
                },
                new Skill()
                {
                    Name = "Linguistics",
                    Description = "Knowledge of other languages",
                    Caste = savedCastes.Single(x => x.Name == "Eclipse")
                },
                new Skill()
                {
                    Name = "Lore",
                    Description = "Academic knowledge",
                    Caste = savedCastes.Single(x => x.Name == "Twlight")
                },
                new Skill()
                {
                    Name = "MartialArts",
                    Description = "Formal unarmed combat styles",
                    Caste = savedCastes.Single(x => x.Name == "Dawn")
                },
                new Skill()
                {
                    Name = "Medicine",
                    Description = "Knowledge of the body",
                    Caste = savedCastes.Single(x => x.Name == "Twlight")
                },
                new Skill()
                {
                    Name = "Melee",
                    Description = "Skill with close combat weapons",
                    Caste = savedCastes.Single(x => x.Name == "Dawn")
                },
                new Skill()
                {
                    Name = "Occult",
                    Description = "Knowledge of supernatural",
                    Caste = savedCastes.Single(x => x.Name == "Twlight")
                },
                new Skill()
                {
                    Name = "Performance",
                    Description = "Acting and performing correct worship",
                    Caste = savedCastes.Single(x => x.Name == "Zenith")
                },
                new Skill()
                {
                    Name = "Presence",
                    Description = "Personal magnatism",
                    Caste = savedCastes.Single(x => x.Name == "Zenith")
                },
                new Skill()
                {
                    Name = "Resistence",
                    Description = "Ability to withstand physical hardship",
                    Caste = savedCastes.Single(x => x.Name == "Zenith")
                },
                new Skill()
                {
                    Name = "Ride",
                    Description = "Controlling a mount",
                    Caste = savedCastes.Single(x => x.Name == "Eclipse")
                },
                new Skill()
                {
                    Name = "Sail",
                    Description = "Controlling a vessel",
                    Caste = savedCastes.Single(x => x.Name == "Eclipse")
                },
                new Skill()
                {
                    Name = "Socialize",
                    Description = "Working within a formal social situation",
                    Caste = savedCastes.Single(x => x.Name == "Eclipse")
                }
            };
            foreach (var skill in skills)
            {
                context.SkillRepository.Save(skill);
            }
        }
    }
}
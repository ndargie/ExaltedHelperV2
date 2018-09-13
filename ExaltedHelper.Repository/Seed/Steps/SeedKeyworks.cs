using System.Collections.Generic;
using ExaltedHelper.Domain.Entities;
using NHibernate.Mapping;

namespace ExaltedHelper.Repository.Seed.Steps
{
    public class SeedKeyworks : SeedStepDefinition
    {
        protected override void ExecuteStep(ref DatabaseInitializer context)
        {
            List<Keyword> keywords = new List<Keyword>()
            {
                new Keyword() {Name = "Combo-OK", Description = "Can be comboed"},
                new Keyword() {Name = "Obvious", Description = "Obvious magic affect"},
                new Keyword() {Name = "Knockback", Description = "Causes knockback"},
                new Keyword() {Name = "Combo-Basic", Description = ""},
                new Keyword() {Name = "Crippling", Description = "Causes crippling affect"},
                new Keyword() {Name = "None", Description = "No keywords"},
                new Keyword() {Name = "Holy", Description = "Highly affective against creatures of darkiness"},
                new Keyword() {Name = "CounterAttack", Description = "Must be used in a counter attack"},
                new Keyword() {Name = "War", Description = "Used to control military units"},
                new Keyword() {Name = "Social", Description = "Social charm"},
                new Keyword() {Name = "Touch", Description = "Requires touch to use"},
                new Keyword() {Name = "Training", Description = "Effect requiring training time"},
                new Keyword() {Name= "Compulsion", Description = "Unatural mental affect"},
                new Keyword() {Name = "Servitude", Description = "Force another person to do something"},
                new Keyword() {Name = "Shaping", Description = "Manipulate the Wyld"},
                new Keyword() {Name = "Stackable", Description = "Allows users to stack charm affects"},
                new Keyword() {Name = "Emotion", Description = "Manipulates emotions"},
                new Keyword() {Name = "Illusion", Description = "Mind affecting images"},
            };
            foreach (var keyword in keywords)
            {
                context.KeywordRepository.Save(keyword);
            }
        }
    }
}
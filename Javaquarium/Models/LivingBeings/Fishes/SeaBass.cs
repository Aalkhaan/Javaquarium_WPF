using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class SeaBass : AbstractFish
    {
        public SeaBass(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatDelegateProperty = new EatBehaviour(HerbivorousEat);
        }

        protected override void GiveBirth()
        {
            SeaBass newBorn = new(Aquarium, RandomManager.GetRandomSex());
            Aquarium.Fishes.Add(newBorn);
        }
    }
}

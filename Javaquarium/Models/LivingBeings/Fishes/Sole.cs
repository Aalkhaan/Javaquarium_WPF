using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class Sole : AbstractFish
    {
        public Sole(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatDelegateProperty = new EatDelegate(HerbivorousEat);
        }

        protected override void GiveBirth()
        {
            Sole newBorn = new(Aquarium, RandomManager.GetRandomSex());
            Aquarium.Fishes.Add(newBorn);
        }
    }
}

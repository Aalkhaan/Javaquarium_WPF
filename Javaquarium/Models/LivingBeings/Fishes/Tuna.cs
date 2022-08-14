using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class Tuna : AbstractFish
    {
        public Tuna(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatDelegateProperty = new EatBehaviour(CarnivorousEat);
        }

        protected override void GiveBirth()
        {
            Tuna newBorn = new(Aquarium, RandomManager.GetRandomSex());
            Aquarium.Fishes.Add(newBorn);
        }
    }
}

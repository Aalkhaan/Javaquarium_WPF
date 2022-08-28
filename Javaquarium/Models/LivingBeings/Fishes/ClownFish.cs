using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class ClownFish : AbstractFish
    {
        public ClownFish(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatDelegateProperty = new EatBehaviour(CarnivorousEat);
        }

        protected override void GiveBirth()
        {
            ClownFish newBorn = new(Aquarium, RandomManager.GetRandomSex());
            Aquarium.FishList.Add(newBorn);
        }
    }
}

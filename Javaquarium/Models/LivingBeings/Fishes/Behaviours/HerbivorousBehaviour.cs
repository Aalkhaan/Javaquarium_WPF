using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes.Behaviours
{
    internal class HerbivorousBehaviour : AbstractEatBehaviour
    {
        public HerbivorousBehaviour(AbstractFish fish) : base(fish)
        {
        }

        public override void Eat()
        {
            int seaweedToEatIndex = RandomManager.Random.Next(Fish.Aquarium.Seaweeds.Count);
            AbstractFish seaweedToEat = Fish.Aquarium.Fishes[seaweedToEatIndex];

            Fish.LifePoints += 3;
            seaweedToEat.GettingEaten();
        }
    }
}

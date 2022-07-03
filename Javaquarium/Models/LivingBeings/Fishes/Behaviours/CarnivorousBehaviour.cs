using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes.Behaviours
{
    public class CarnivorousBehaviour : AbstractEatBehaviour
    {
        public CarnivorousBehaviour(AbstractFish fish) : base(fish)
        {
        }

        public override void Eat()
        {
            int fishToEatIndex = RandomManager.Random.Next(Fish.Aquarium.Fishes.Count);
            AbstractFish fishToEat = Fish.Aquarium.Fishes[fishToEatIndex];

            // un poisson ne peut ni manger un autre poisson de la même race, ni lui même
            if (Fish.GetType() == fishToEat.GetType()) return;

            Fish.LifePoints += 5;
            fishToEat.GettingEaten();
        }
    }
}

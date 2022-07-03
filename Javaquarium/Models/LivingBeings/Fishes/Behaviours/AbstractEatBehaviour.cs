using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes.Behaviours
{
    internal abstract class AbstractEatBehaviour
    {
        protected AbstractFish Fish { get; init; }

        protected AbstractEatBehaviour(AbstractFish fish)
        {
            Fish = fish;
        }

        public abstract void Eat();
    }
}

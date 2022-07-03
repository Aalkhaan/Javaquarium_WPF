using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Seaweeds
{
    public class Seaweed : AbstractLivingBeing
    {
        public Seaweed(Aquarium aquarium) : base(aquarium)
        {
        }

        public override void GettingEaten() => LifePoints -= 2;

        protected override void Die() => Aquarium.Seaweeds.Remove(this);

        public override void GrowOld()
        {
            // l'algue grandit
            ++LifePoints;
            base.GrowOld();
        }
    }
}

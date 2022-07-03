using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Seaweeds
{
    internal class Seaweed : AbstractLivingBeing
    {
        public Seaweed(Aquarium aquarium) : base(aquarium)
        {
        }

        public override void GettingEaten() => LifePoints -= 2;

        protected override void Die()
        {
            IsAlive = false;
            Aquarium.Seaweeds.Remove(this);
        }

        public void Grow() => ++LifePoints;
    }
}

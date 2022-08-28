using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Seaweeds
{
    public class Seaweed : AbstractLivingBeing
    {
        public Seaweed(Aquarium aquarium) : base(aquarium) { }

        public override void GettingEaten() => LifePoints -= 2;

        protected override void Die() => Aquarium.SeaweedList.Remove(this);

        public override void GrowOld()
        {
            // l'algue grandit
            ++LifePoints;
            base.GrowOld();
        }

        protected override void Reproduce()
        {
            // l'algue se sépare en deux pour donner naissance à une nouvelle algue
            int newSeaweedLifePoints = LifePoints >> 1;
            LifePoints -= newSeaweedLifePoints;

            Seaweed newSeaweed = new(Aquarium)
            {
                LifePoints = newSeaweedLifePoints
            };
            Aquarium.SeaweedList.Add(newSeaweed);
        }

        public override void Acts()
        {
            if (LifePoints >= 10)
                Reproduce();
        }
    }
}

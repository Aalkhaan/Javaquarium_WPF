using Javaquarium.Models.LivingBeings.Fishes.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    internal abstract class AbstractFish : AbstractLivingBeing
    {
        public string Name { get; init; }
        public Sex Sex { get; init; }
        protected AbstractEatBehaviour EatBehaviour { get; init; }

        protected AbstractFish(Aquarium aquarium, Sex sex, string name = "") : base(aquarium)
        {
            Sex = sex;
            Name = name;
        }

        public void Eat()
        {
            --LifePoints;
            if (IsAlive) EatBehaviour.Eat();
        }

        public override void GettingEaten() => LifePoints -= 4;

        protected override void Die()
        {
            IsAlive = false;
            Aquarium.Fishes.Remove(this);
        }
    }
}

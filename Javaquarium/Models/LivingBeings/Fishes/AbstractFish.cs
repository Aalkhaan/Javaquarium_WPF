using Javaquarium.Models.LivingBeings.Fishes.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public abstract class AbstractFish : AbstractLivingBeing, IComparable<AbstractFish>
    {
        public string Name { get; init; }
        public Sex Sex { get; init; }
        protected AbstractEatBehaviour? EatBehaviour { get; init; }
        private bool IsAlive { get => LifePoints > 0; }
        private bool IsHungry { get => LifePoints <= 5; }

        protected AbstractFish(Aquarium aquarium, Sex sex, string name = "") : base(aquarium)
        {
            Sex = sex;
            Name = name;
        }

        public void Eat()
        {
            if (IsAlive && IsHungry) EatBehaviour?.Eat();
        }

        public override void GettingEaten() => LifePoints -= 4;

        protected override void Die() => Aquarium.Fishes.Remove(this);

        public override void GrowOld()
        {
            // à chaque tour, le poisson a de plus en plus faim
            --LifePoints;
            base.GrowOld();
        }

        public override string? ToString()
        {
            string absoluteRace = GetType().ToString();
            int lastPointIndex = absoluteRace.LastIndexOf('.');
            if (lastPointIndex == -1)
                return "Race: " + absoluteRace + ", " + base.ToString();

            string race = absoluteRace[(lastPointIndex + 1)..];
            return "Race: " + race + ", " + base.ToString();

        }

        public int CompareTo(AbstractFish? other)
        {
            if (other == null) return -1;

            // compare par type
            Type t = GetType();
            Type otherT = other.GetType();
            if (t != otherT) return otherT.ToString().CompareTo(t.ToString());

            // puis par points de vie
            return other.LifePoints.CompareTo(LifePoints);
        }
    }
}

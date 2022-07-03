using Javaquarium.Models.LivingBeings.Fishes.Enums;
using Javaquarium.Models.LivingBeings.Seaweeds;
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
        public Sex Sex { get; private set; }
        protected Sexuality Sexuality { get; init; }
        public override int Age
        {
            get => base.Age;
            set
            {
                base.Age = value;

                if (value == 10 && Sexuality == Sexuality.HERMAPHRODITE_WITH_AGE)
                    SwitchSex();
            }
        }
        public bool IsAlive { get => LifePoints > 0; }
        private bool IsHungry { get => LifePoints <= 5; }
        protected EatDelegate? EatDelegateProperty { get; set; }
        protected delegate void EatDelegate();

        protected AbstractFish(Aquarium aquarium, Sex sex, string name = "") : base(aquarium)
        {
            Sex = sex;
            Name = name;
        }

        private void Eat() => EatDelegateProperty?.Invoke();

        protected override void Reproduce()
        {
            if (Aquarium.Fishes.Count == 0) return;

            int partnerIndex = RandomManager.Random.Next(Aquarium.Fishes.Count);
            AbstractFish partner = Aquarium.Fishes[partnerIndex];
            Type type = GetType();

            if (type != partner.GetType() || this == partner) return;

            if (Sex == partner.Sex)
            {
                if (Sexuality != Sexuality.OPPORTUNISTIC_HERMAPHRODITE) return;
                SwitchSex();
            }

            GiveBirth();
        }

        protected abstract void GiveBirth();

        public override void Acts()
        {
            if (IsHungry) Eat();
            else Reproduce();
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

        protected void CarnivorousEat()
        {
            if (Aquarium.Fishes.Count == 0) return;

            int fishToEatIndex = RandomManager.Random.Next(Aquarium.Fishes.Count);
            AbstractFish fishToEat = Aquarium.Fishes[fishToEatIndex];

            // un poisson ne peut ni manger un autre poisson de la même race, ni lui même
            if (GetType() == fishToEat.GetType()) return;

            LifePoints += 5;
            fishToEat.GettingEaten();
        }

        protected void HerbivorousEat()
        {
            if (Aquarium.Seaweeds.Count == 0) return;

            int seaweedToEatIndex = RandomManager.Random.Next(Aquarium.Seaweeds.Count);
            Seaweed seaweedToEat = Aquarium.Seaweeds[seaweedToEatIndex];

            LifePoints += 3;
            seaweedToEat.GettingEaten();
        }

        private void SwitchSex()
        {
            if (Sex == Sex.MALE) Sex = Sex.FEMALE;
            else Sex = Sex.MALE;
        }
    }
}

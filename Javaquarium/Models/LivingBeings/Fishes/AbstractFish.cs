using Javaquarium.Models.LivingBeings.Fishes.Enums;
using Javaquarium.Models.LivingBeings.Seaweeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public abstract class AbstractFish : AbstractLivingBeing, IComparable<AbstractFish>
    {
        private const int HungerThreshold = 5;
        public string Name { get; init; }
        public Sex Sex { get; private set; }
        protected Sexuality Sexuality { get; init; }
        public override int Age
        {
            get => base.Age;
            set
            {
                base.Age = value;

                if (value == 10 && Sexuality == Sexuality.HermaphroditeWithAge)
                    SwitchSex();
            }
        }
        private bool IsHungry => LifePoints <= HungerThreshold;
        protected EatBehaviour? EatDelegateProperty { get; set; }
        protected delegate void EatBehaviour();

        protected AbstractFish(Aquarium aquarium, Sex sex, string name = "") : base(aquarium)
        {
            Sex = sex;
            Name = name;
        }

        private void Eat() => EatDelegateProperty?.Invoke();

        protected override void Reproduce()
        {
            if (Aquarium.Fishes.Count == 0)
                return;

            int partnerIndex = RandomNumberGenerator.GetInt32(Aquarium.Fishes.Count);
            AbstractFish partner = Aquarium.Fishes[partnerIndex];

            if (GetType() != partner.GetType() || this == partner)
                return;

            if (Sex == partner.Sex)
            {
                if (Sexuality != Sexuality.OpportunisticHermaphrodite)
                    return;

                SwitchSex();
            }

            GiveBirth();
        }

        protected abstract void GiveBirth();

        public override void Acts()
        {
            if (IsHungry)
                Eat();
            else
                Reproduce();
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

        protected void CarnivorousEat()
        {
            if (Aquarium.Fishes.Count == 0)
                return;

            int fishToEatIndex = RandomNumberGenerator.GetInt32(Aquarium.Fishes.Count);
            AbstractFish fishToEat = Aquarium.Fishes[fishToEatIndex];

            // un poisson ne peut ni manger un autre poisson de la même race, ni lui même
            if (GetType() == fishToEat.GetType())
                return;

            LifePoints += 5;
            fishToEat.GettingEaten();
        }

        protected void HerbivorousEat()
        {
            if (Aquarium.Seaweeds.Count == 0)
                return;

            int seaweedToEatIndex = RandomNumberGenerator.GetInt32(Aquarium.Seaweeds.Count);
            Seaweed seaweedToEat = Aquarium.Seaweeds[seaweedToEatIndex];

            LifePoints += 3;
            seaweedToEat.GettingEaten();
        }

        private void SwitchSex()
        {
            if (Sex == Sex.Male)
                Sex = Sex.Female;
            else
                Sex = Sex.Male;
        }

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);

        public int CompareTo(AbstractFish? other)
        {
            if (other is null)
                return -1;

            // on compare par nom du type de poisson
            Type thisType = GetType();
            Type otherType = other.GetType();
            if (thisType != otherType)
                return string.CompareOrdinal(thisType.ToString(), otherType.ToString());

            // puis par points de vie
            return LifePoints.CompareTo(other.LifePoints);
        }

        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(AbstractFish left, AbstractFish right) => ReferenceEquals(left, right);
        public static bool operator !=(AbstractFish left, AbstractFish right) => !(left == right);
        public static bool operator <(AbstractFish left, AbstractFish right) => left is null ? right is not null : left.CompareTo(right) < 0;
        public static bool operator <=(AbstractFish left, AbstractFish right) => left is null || left.CompareTo(right) <= 0;
        public static bool operator >(AbstractFish left, AbstractFish right) => left is not null && left.CompareTo(right) > 0;
        public static bool operator >=(AbstractFish left, AbstractFish right) => left is null ? right is null : left.CompareTo(right) >= 0;
    }
}

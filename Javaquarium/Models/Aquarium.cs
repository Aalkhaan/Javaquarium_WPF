using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Seaweeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    internal class Aquarium
    {
        public List<Seaweed> Seaweeds { get; init; }
        public List<AbstractFish> Fishes { get; init; }

        public Aquarium()
        {
            Seaweeds = new(20);
            for (int i = 0; i < 20; ++i)
                Seaweeds[i] = new(this);

            Fishes = new()
            {
                new Carp(this, Sex.MALE),
                new Carp(this, Sex.FEMALE),
                new ClownFish(this, Sex.MALE),
                new ClownFish(this, Sex.FEMALE),
                new Grouper(this, Sex.MALE),
                new Grouper(this, Sex.FEMALE),
                new SeaBass(this, Sex.MALE),
                new SeaBass(this, Sex.FEMALE),
                new Sole(this, Sex.MALE),
                new Sole(this, Sex.FEMALE),
                new Tuna(this, Sex.MALE),
                new Tuna(this, Sex.FEMALE)
            };
        }
    }
}

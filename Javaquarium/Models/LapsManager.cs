using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Seaweeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    internal class LapsManager
    {
        private Aquarium Aquarium { get; set; }

        public LapsManager(Aquarium aquarium)
        {
            Aquarium = aquarium;
        }

        public void Reset() => Aquarium = new Aquarium();

        public void NextLap()
        {
            List<Seaweed> seaweeds = new(Aquarium.Seaweeds);
            List<AbstractFish> fishes = new(Aquarium.Fishes);

            // les êtres vivants vieillissent
            foreach (Seaweed seaweed in seaweeds) seaweed.GrowOld();
            foreach (AbstractFish fish in fishes) fish.GrowOld();

            // certains meurent de vieillesse, on actualise
            seaweeds = new(Aquarium.Seaweeds);
            fishes = new(Aquarium.Fishes);

            foreach (AbstractFish fish in fishes) fish.Eat();
        }
    }
}

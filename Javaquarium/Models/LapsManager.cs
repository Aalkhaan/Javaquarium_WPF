using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Seaweeds;
using Javaquarium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    public class LapsManager
    {
        private ViewModel ViewModel { get; init; }
        private Aquarium Aquarium { get; set; }

        public LapsManager(Aquarium aquarium, ViewModel viewModel)
        {
            Aquarium = aquarium;
            ViewModel = viewModel;
            ViewModel.Lap = 0;
        }

        /// <summary>
        /// Réinitialise l'état de l'aquarium.
        /// </summary>
        public void Reset()
        {
            Aquarium = new Aquarium();
            ViewModel.Aquarium = Aquarium;
            ViewModel.Lap = 0;
        }

        /// <summary>
        /// Passe un tour.
        /// </summary>
        public void NextLap()
        {
            List<Seaweed> seaweeds = new(Aquarium.Seaweeds);
            FishList fishes = new(Aquarium.Fishes);

            // les êtres vivants vieillissent
            foreach (var seaweed in seaweeds) seaweed.GrowOld();
            foreach (var fish in fishes) fish.GrowOld();

            // certain poissons meurent de vieillesse, on actualise
            fishes = new(Aquarium.Fishes);

            // les poissons mangent
            foreach (var fish in fishes) fish.Eat();

            ++ViewModel.Lap;
        }
    }
}

using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Seaweeds;
using Javaquarium.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    public class LapsManager
    {
        public LapsManagerVM LapsManagerVM { get; init; }
        public Aquarium Aquarium { get; init; }
        public int Lap { get; set; }

        public LapsManager(LapsManagerVM lapsManagerVM, Aquarium aquarium)
        {
            LapsManagerVM = lapsManagerVM;
            Aquarium = aquarium;
        }

        /// <summary>
        /// Réinitialise l'état de l'aquarium.
        /// </summary>
        public void Reset()
        {
            Aquarium.Clear();
            LapsManagerVM.NotifyView();
        }

        /// <summary>
        /// Passe un tour.
        /// </summary>
        public void NextLap()
        {
            // on doit copier les listes car la méthode Acts supprime éventuellement des éléments de SeaweedList et FishList
            List<Seaweed> currentSeaweedList = new(Aquarium.SeaweedList);
            List<AbstractFish> currentFishList = new(Aquarium.FishList);

            // les êtres vivants vieillissent
            currentSeaweedList.ForEach(seaweed => seaweed.GrowOld());
            currentFishList.ForEach(fish => fish.GrowOld());

            // certain poissons meurent de vieillesse, on actualise donc la liste
            currentFishList = new(Aquarium.FishList);

            // les algues et les poissons font leur action
            currentSeaweedList.ForEach(seaweed => seaweed.Acts());
            foreach (AbstractFish fish in currentFishList)
            {
                if (fish.IsAlive)
                    fish.Acts();
            }

            ++Lap;
        }
    }
}

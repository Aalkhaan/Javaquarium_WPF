using Javaquarium.Models;
using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Fishes.Enums;
using Javaquarium.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Javaquarium.ViewModels
{
    public class AquariumEditionVM : ViewModelBase
    {
        public MainWindowVM MainWindowVM { get; init; }
        public Aquarium Aquarium { get; init; }
        public ObservableCollection<AbstractFish> Fishes { get; } = new();
        public int NbSeaweeds
        {
            get => _nbSeaweeds;
            set
            {
                _nbSeaweeds = value;
                OnPropertyChanged();
            }
        }
        private int _nbSeaweeds;
        public Race FishRace { get; set; }
        public Sex FishSex { get; set; }
        public string FishName
        {
            get => _fishName;
            set
            {
                _fishName = value;
                OnPropertyChanged();
            }
        }
        private string _fishName = "test";

        public Command AddFishCmd { get; init; }
        public Command ClearAquariumCmd { get; init; }
        public Command ValidateCmd { get; init; }

        public AquariumEditionVM(MainWindowVM mainWindowVM, Aquarium aquarium)
        {
            MainWindowVM = mainWindowVM;
            Aquarium = aquarium;

            AddFishCmd = new(AddFish);
            ClearAquariumCmd = new(ClearAquarium);
            ValidateCmd = new(Validate);
        }

        private void AddFish()
        {
            AbstractFish newFish = FishRace switch
            {
                Race.Carp => new Carp(Aquarium, FishSex, FishName),
                Race.ClownFish => new ClownFish(Aquarium, FishSex, FishName),
                Race.Grouper => new Grouper(Aquarium, FishSex, FishName),
                Race.SeaBass => new SeaBass(Aquarium, FishSex, FishName),
                Race.Sole => new Sole(Aquarium, FishSex, FishName),
                Race.Tuna => new Tuna(Aquarium, FishSex, FishName),
                _ => new Carp(Aquarium, FishSex, FishName),
            };

            Fishes.Add(newFish);
        }

        private void ClearAquarium()
        {
            Fishes.Clear();
            OnPropertyChanged(nameof(Fishes));
        }

        private void Validate() { }
    }
}

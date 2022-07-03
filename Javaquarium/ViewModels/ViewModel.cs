using Javaquarium.Models;
using Javaquarium.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Javaquarium.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        public LapsManager LapsManager { get; init; }
        public Aquarium Aquarium { get; set; }
        public int Lap
        {
            get => _lap;
            set
            {
                _lap = value;
                OnPropertyChanged();
            }
        }
        private int _lap;
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
        public string FishesDisplay
        {
            get => _fishesDisplay;
            set
            {
                _fishesDisplay = value;
                OnPropertyChanged();
            }
        }
        private string _fishesDisplay = "";
        public Command ResetCommand { get; init; }
        public Command NextLapCommand { get; init; }

        public ViewModel()
        {
            Aquarium = new();
            LapsManager = new(Aquarium, this);
            NotifyView();

            ResetCommand = new(Reset);
            NextLapCommand = new(NextLap);
        }

        public void Reset()
        {
            LapsManager.Reset();
            NotifyView();
        }

        public void NextLap()
        {
            LapsManager.NextLap();
            NotifyView();
        }

        /// <summary>
        /// Affecte aux propriétés nécéssaires requises par la view leurs valeurs.
        /// </summary>
        private void NotifyView()
        {
            NbSeaweeds = Aquarium.Seaweeds.Count;

            Aquarium.Fishes.Sort();
            FishesDisplay = Aquarium.Fishes.ToString();
        }
    }
}

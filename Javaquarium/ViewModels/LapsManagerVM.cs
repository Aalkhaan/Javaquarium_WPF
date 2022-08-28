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
    public class LapsManagerVM : ViewModelBase
    {
        public MainWindowVM MainWindowVM { get; init; }
        public LapsManager LapsManager { get; init; }
        public Aquarium Aquarium => LapsManager.Aquarium;
        public int Lap => LapsManager.Lap;
        public int NbSeaweeds => Aquarium.SeaweedList.Count;
        public Command ResetCommand { get; init; }
        public Command NextLapCommand { get; init; }

        public LapsManagerVM(MainWindowVM mainWindowVM, Aquarium aquarium)
        {
            MainWindowVM = mainWindowVM;
            LapsManager = new(this, aquarium);

            NotifyView();

            ResetCommand = new Command(Reset);
            NextLapCommand = new Command(NextLap);
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
        public void NotifyView() => OnPropertyChanged(string.Empty);
    }
}

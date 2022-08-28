using Javaquarium.Models;
using Javaquarium.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public AquariumEditionVM AquariumEditionVM { get; init; }
        public LapsManagerVM LapsManagerVM { get; init; }
        public MenuNavigation SelectedNavigation
        {
            get => _selectedNavigation;
            set
            {
                _selectedNavigation = value;
                OnPropertyChanged();
            }
        }
        private MenuNavigation _selectedNavigation = MenuNavigation.AquariumEdition;

        public MainWindowVM()
        {
            Aquarium aquarium = new();
            AquariumEditionVM = new(this, aquarium);
            LapsManagerVM = new(this, aquarium);
        }
    }
}

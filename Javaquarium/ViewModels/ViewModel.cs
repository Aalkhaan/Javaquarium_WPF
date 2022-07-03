using Javaquarium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.ViewModels
{
    internal class ViewModel : ViewModelBase
    {
        private LapsManager LapsManager { get; init; }

        public ViewModel()
        {
            LapsManager = new LapsManager(new Aquarium());
        }

        public void ResetClick()
        {

        }
    }
}

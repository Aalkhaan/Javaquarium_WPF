using Javaquarium.Models.LivingBeings.Fishes.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    internal class SeaBass : AbstractFish
    {
        public SeaBass(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatBehaviour = new HerbivorousBehaviour(this);
        }
    }
}

using Javaquarium.Models.LivingBeings.Fishes.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class Sole : AbstractFish
    {
        public Sole(Aquarium aquarium, Sex sex, string name = "") : base(aquarium, sex, name)
        {
            EatBehaviour = new HerbivorousBehaviour(this);
        }
    }
}

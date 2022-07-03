using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes
{
    public class FishList : List<AbstractFish>
    {
        public FishList()
        {
        }

        public FishList(IEnumerable<AbstractFish> collection) : base(collection)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new("");
            foreach (var fish in this)
                sb.Append(fish.ToString()).Append('\n');

            return sb.ToString();
        }
    }
}

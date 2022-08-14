using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes.Enums
{
    public enum Sexuality
    {
        MonoSexual,

        // change de sexe au bout de 10 ans
        HermaphroditeWithAge,

        // change de sexe si nécessaire à chaque accouplement
        OpportunisticHermaphrodite
    }
}

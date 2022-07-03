using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings.Fishes.Enums
{
    public enum Sexuality
    {
        MONO_SEXUAL,

        // change de sexe au bout de 10 ans
        HERMAPHRODITE_WITH_AGE,

        // change de sexe dès qu'il en a besoin pour se reproduire
        OPPORTUNISTIC_HERMAPHRODITE
    }
}

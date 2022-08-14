using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    public static class RandomManager
    {
        public static Sex GetRandomSex() => (Sex)RandomNumberGenerator.GetInt32(2);
    }
}

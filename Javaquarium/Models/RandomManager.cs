using Javaquarium.Models.LivingBeings.Fishes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    public class RandomManager
    {
        public static Random Random { get; } = new Random();

        public static Sex GetRandomSex() => (Sex)Random.Next(2);
    }
}

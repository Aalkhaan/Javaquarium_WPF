using Javaquarium.Models.LivingBeings.Fishes;
using Javaquarium.Models.LivingBeings.Fishes.Enums;
using Javaquarium.Models.LivingBeings.Seaweeds;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models
{
    public class Aquarium
    {
        internal List<Seaweed> SeaweedList { get; } = new();
        internal List<AbstractFish> FishList { get; private set; } = new();

        public Aquarium() { }

        public void PopulateDefault()
        {
            Clear();

            for (int i = 0; i < 20; ++i)
                SeaweedList.Add(new(this));

            FishList = new()
            {
                new Carp(this, Sex.Male),
                new Carp(this, Sex.Female),
                new ClownFish(this, Sex.Male),
                new ClownFish(this, Sex.Female),
                new Grouper(this, Sex.Male),
                new Grouper(this, Sex.Female),
                new SeaBass(this, Sex.Male),
                new SeaBass(this, Sex.Female),
                new Sole(this, Sex.Male),
                new Sole(this, Sex.Female),
                new Tuna(this, Sex.Male),
                new Tuna(this, Sex.Female)
            };
        }

        public void Clear()
        {
            SeaweedList.Clear();
            FishList.Clear();
        }
    }
}

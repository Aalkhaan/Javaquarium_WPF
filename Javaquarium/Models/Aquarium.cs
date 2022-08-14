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
        public Collection<Seaweed> Seaweeds { get; init; } = new();
        public ObservableCollection<AbstractFish> Fishes { get; init; } = new();

        public Aquarium() { }

        public void PopulateDefault()
        {
            Clear();

            for (int i = 0; i < 20; ++i)
                Seaweeds.Add(new(this));

            Fishes.Add(new Carp(this, Sex.Male));
            Fishes.Add(new Carp(this, Sex.Female));
            Fishes.Add(new ClownFish(this, Sex.Male));
            Fishes.Add(new ClownFish(this, Sex.Female));
            Fishes.Add(new Grouper(this, Sex.Male));
            Fishes.Add(new Grouper(this, Sex.Female));
            Fishes.Add(new SeaBass(this, Sex.Male));
            Fishes.Add(new SeaBass(this, Sex.Female));
            Fishes.Add(new Sole(this, Sex.Male));
            Fishes.Add(new Sole(this, Sex.Female));
            Fishes.Add(new Tuna(this, Sex.Male));
            Fishes.Add(new Tuna(this, Sex.Female));
        }

        public void Clear()
        {
            Seaweeds.Clear();
            Fishes.Clear();
        }
    }
}

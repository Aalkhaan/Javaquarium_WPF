﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings
{
    public abstract class AbstractLivingBeing
    {
        private const int BaseLifePoints = 10;
        public Aquarium Aquarium { get; init; }
        protected int LifePoints
        {
            get => _lifePoints;
            set
            {
                _lifePoints = value;
                if (_lifePoints <= 0)
                    Die();
            }
        }
        private int _lifePoints = BaseLifePoints;
        public virtual int Age
        {
            get => _age;
            set
            {
                _age = value;
                // les êtres vivants meurent de vieillesse au bout de 20 tours
                if (_age >= 20)
                    Die();
            }
        }
        private int _age;
        public bool IsAlive => LifePoints > 0;

        protected AbstractLivingBeing(Aquarium aquarium)
        {
            Aquarium = aquarium;
        }

        public abstract void GettingEaten();

        /// <summary>
        /// Supprime l'être vivant de l'aquarium.
        /// </summary>
        protected abstract void Die();

        /// <summary>
        /// Incrémente l'âge.
        /// </summary>
        public virtual void GrowOld() => ++Age;

        protected abstract void Reproduce();

        public abstract void Acts();

        public override string? ToString() => "Age: " + Age + ", Life Points: " + LifePoints;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javaquarium.Models.LivingBeings
{
    internal abstract class AbstractLivingBeing
    {
        public Aquarium Aquarium { get; init; }
        public bool IsAlive { get; protected set; } = true;
        public int LifePoints
        {
            get => _lifePoints;
            set
            {
                _lifePoints = value;
                if (_lifePoints <= 0) Die();
            }
        }
        private int _lifePoints = 10;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                if (_age > 20) Die();
            }
        }
        private int _age = 0;

        internal AbstractLivingBeing(Aquarium aquarium)
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
        public void GrowOld() => ++Age;
    }
}

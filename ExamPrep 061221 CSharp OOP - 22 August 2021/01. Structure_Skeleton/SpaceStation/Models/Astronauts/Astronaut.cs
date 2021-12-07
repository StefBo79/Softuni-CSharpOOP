using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;

            this.bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen 
        { 
            get => oxygen;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                this.oxygen = value;
            } 
        }

        public bool CanBreath
            => this.Oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            this.Oxygen -= 10;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const string DoughExeptionMessage = "Invalid type of dough.";
        private const string WeightExeptionMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeCalories
            = new Dictionary<string, double>
            {
                {"white", 1.5 },
                {"wholegrain", 1.0 },
            };

        private Dictionary<string, double> backingTechniqueCalories
            = new Dictionary<string, double>
            {
                {"crispy", 0.9 },
                {"chewy", 1.1 },
                {"homemade", 1.0},
            };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExeptionMessage);
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {             
            get
            { 
                return bakingTechnique; 
            }
            private set 
            {
                if (!backingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExeptionMessage);
                }
                bakingTechnique = value; 
            }
        }

        public double Weight
        {
            get 
            { 
                return weight; 
            }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightExeptionMessage);
                }
                weight = value; 
            }
        }

        public double Calories
            => 2 * Weight * this.flourTypeCalories[this.FlourType.ToLower()] 
            * this.backingTechniqueCalories[this.BakingTechnique.ToLower()];
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {        
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }       

        public int Endurance
        {
            get => endurance;
            private set
            {
                ValidateStat(nameof(Endurance), value);
                endurance = value;
            }
        }

        public int Sprint 
        { 
            get => sprint;
            private set
            {
                ValidateStat(nameof(Sprint), value);
                sprint = value;
            } 
        }
        public int Dribble 
        { 
            get => dribble;
            private set
            {
                ValidateStat(nameof(Dribble), value);
                dribble = value;
            } 
        }
        public int Passing 
        { 
            get => passing;
            private set
            {
                ValidateStat(nameof(Passing), value);
                passing = value; 
            }
        }
        public int Shooting 
        { 
            get => shooting;
            private set
            {
                ValidateStat(nameof(Shooting), value);
                shooting = value; 
            }
        }

        public double Stats
            => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private void ValidateStat(string varName, int value)
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException($"{varName} should be between 0 and 100.");
            }
        }
    }
}

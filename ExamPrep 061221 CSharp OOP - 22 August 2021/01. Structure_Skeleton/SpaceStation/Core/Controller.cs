using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController

    {
        private readonly IRepository<IAstronaut> astronautRepo;
        private readonly IRepository<IPlanet> planetRepo;
        private readonly IMission mission;
        private int explorePlanet;

        public Controller()
        {
            this.astronautRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            this.astronautRepo.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepo.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronautRepo
                .Models
                .Where(x => x.Oxygen > 60)
                .ToList();

            if (!astronauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            explorePlanet++;

            var planet = this.planetRepo.FindByName(planetName);
            this.mission.Explore(planet, astronauts);

            var deadAstronauts = 0;
            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    deadAstronauts++;
                }
            }

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{explorePlanet} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                string itemInfo = astronaut.Bag.Items.Any() ?
                    string.Join(", ", astronaut.Bag.Items) :
                    "none";

                sb.AppendLine($"Bag items: {itemInfo}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepo.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException("Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepo.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}

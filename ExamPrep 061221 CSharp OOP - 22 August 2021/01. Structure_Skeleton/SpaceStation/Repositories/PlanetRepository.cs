using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> astronauts;

        public PlanetRepository()
        {
            this.astronauts = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => astronauts;

        public void Add(IPlanet model)
            => this.astronauts.Add(model);

        public IPlanet FindByName(string name)
            => this.astronauts.FirstOrDefault(x => x.Name == name);

        public bool Remove(IPlanet model)
            => this.astronauts.Remove(model);
    }
}

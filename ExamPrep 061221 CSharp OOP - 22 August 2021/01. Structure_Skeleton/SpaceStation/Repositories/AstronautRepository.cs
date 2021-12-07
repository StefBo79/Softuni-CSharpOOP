using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => astronauts;

        public void Add(IAstronaut model)
            => this.astronauts.Add(model);

        public IAstronaut FindByName(string name)
            => this.astronauts.FirstOrDefault(x => x.Name == name);

        public bool Remove(IAstronaut model)
            => this.astronauts.Remove(model);
    }
}

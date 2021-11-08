using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            var team = new Team("SoftUni");
            for (int i = 0; i < lines; i++)
            {
                var personArguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstName = personArguments[0];
                string lastName = personArguments[1];
                int age = int.Parse(personArguments[2]);
                decimal salary = decimal.Parse(personArguments[3]);
            }

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);

            //Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            //Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
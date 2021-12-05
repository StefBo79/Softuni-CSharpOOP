using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string operations = Console.ReadLine();

            while (operations != "End")
            {
                string[] info = operations.Split();

                var name = info[0];
                var country = info[1];
                var age = int.Parse(info[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);                

                person.GetName();
                resident.GetName();

                operations = Console.ReadLine();
            }

        }
    }
}
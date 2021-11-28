using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandInfo = command.Split(';');
                string action = commandInfo[0];

                try
                {
                    if (action == "Team")
                    {
                        string name = commandInfo[1];
                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (action == "Add")
                    {
                        string teamName = commandInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        string playerName = commandInfo[2];                        
                        int endurance = int.Parse(commandInfo[3]);
                        int sprint = int.Parse(commandInfo[4]);
                        int dribble = int.Parse(commandInfo[5]);
                        int passing = int.Parse(commandInfo[6]);
                        int shooting = int.Parse(commandInfo[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        string teamName = commandInfo[1];
                        string playerName = commandInfo[2];
                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        string teamName = commandInfo[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}

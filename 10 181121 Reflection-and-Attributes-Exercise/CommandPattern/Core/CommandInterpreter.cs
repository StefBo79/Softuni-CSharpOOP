using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (input[0] + "Command").ToLower();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name.ToLower() == commandName);
            //Console.WriteLine((Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name.ToLower() == commandName).Assembly.Get().Name));
            ICommand instance = (ICommand)Activator.CreateInstance(type ?? throw new ArgumentException("Invalid command type!"));
            string result = instance?.Execute(input.Skip(1).ToArray());
            return result;
        }
    }
}
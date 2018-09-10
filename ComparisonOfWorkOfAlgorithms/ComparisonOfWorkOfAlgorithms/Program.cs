using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComparisonOfWorkOfAlgorithms
{


    class Program
    {
        static Dictionary<string, Func<string[], string>> commands = new Dictionary<string, Func<string[], string>>()
            {
                { "iterations", SortTesting.setIterations},
                { "sequence", SortTesting.setArray},
                {"random", SortTesting.SetRandomArray},
                { "test", SortTesting.Test},
                { "help", help}
            };

        public static string help(string[] args)
        {
            if (args.Length > 1)
                return "У команды help не может быть аргументов.";
            return "Программа тестер скорости сортировок.\nВозможные команды:"
                +String.Join("\n",commands.Keys);
        }

        static void HandleCommand(string[] consoleLine)
        {
            var command = consoleLine[0];
            if (commands.ContainsKey(command))
                Console.WriteLine(commands[command]((string[])consoleLine.Clone()));
            else
                Console.WriteLine("Нет такой комманды.");
        }

        static void Main(string[] args)
        {
            if(args.Length>0)
            {
                var inquiry = File.OpenText(args[0]);
                string input;
                while ((input = inquiry.ReadLine()) != null)
                    HandleCommand(input.Split());
            }
            else
                while (true)
                    HandleCommand(Console.ReadLine().Split());
        }
    }
}

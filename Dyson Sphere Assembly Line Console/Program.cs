using System;
using System.Collections.Generic;
using System.Linq;
using Dyson_Sphere_Assembly_Line_Domain;
using DysonSphereAssembly.DAL.Tools;

namespace Dyson_Sphere_Assembly_Line_Console
{
    class Program
    {
        private static List<Tuple<int, ConsoleColor, ConsoleColor>> colors = new List<Tuple<int, ConsoleColor, ConsoleColor>>
        {
            new Tuple<int, ConsoleColor, ConsoleColor>(1, ConsoleColor.Gray, ConsoleColor.Black),
            new Tuple<int, ConsoleColor, ConsoleColor>(2, ConsoleColor.Blue, ConsoleColor.Black),
            new Tuple<int, ConsoleColor, ConsoleColor>(3, ConsoleColor.Green, ConsoleColor.Black)
        };

        static void Main(string[] args)
        { 
            var connectionString = "Data Source=localhost;Initial Catalog=DysonSphereAssembler;Integrated Security=True";
            //var importTool = new JsonImport(connectionString);
            //importTool.ImportRecipes("C:\\Repo\\PersonalRepo\\DysonSphereAssembler\\Data\\Components.json");

            var builder = new Builder(new UnitOfWorkFactory(connectionString));

            var build =
            builder.CreateBuild(71);

            build.DesiredPerMinute = 60;


            PrintBuildResult(build);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Complete");
            Console.Read();
        }

        private static void PrintBuildResult(Build build)
        {
            Console.WriteLine($"{build.ComponentToBuild.Recipe.Component.Name} needs {build.ComponentToBuild.NumberOfBuilders} {build.ComponentToBuild.Recipe.MachineType}(s)");
            int color = 1;
            foreach (var inputComponent in build.ComponentToBuild.InputComponents)
            {
                var colorsToUse = colors.First(i => i.Item1 == color);
                Console.BackgroundColor = colorsToUse.Item2;
                Console.ForegroundColor = colorsToUse.Item3;
                PrintBuildComponenet(inputComponent, 1);
                color++;
            }
        }

        private static void PrintBuildComponenet(BuildComponent buildComponent, int level)
        {
            var spacesNeeded = level * 5;
            for (int i = 0; i < spacesNeeded; i++)
            {
                Console.Write("-");
            }
            Console.Write($"{buildComponent.Recipe.Component.Name} needs {buildComponent.NumberOfBuilders} {buildComponent.Recipe.MachineType}(s) To Produce {buildComponent.ProducedPerMinute} with a build target of {buildComponent.BuildTargetPerMinute}\r\n");
            foreach (var buildComponentInputComponent in buildComponent.InputComponents)
            {
                PrintBuildComponenet(buildComponentInputComponent, level +1);
            }
        }
    }
}

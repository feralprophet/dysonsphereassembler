using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dyson_Sphere_Assembly_Line_Domain;
using DysonSphereAssembly.DAL.Tools;
using EasyConsole;
using Microsoft.Extensions.Configuration;

namespace Dyson_Sphere_Assembly_Line_Console
{
    class Program
    {
        private static bool verbose = false;
        private static Menu _menu;
        private static IConfiguration _config;
        private static List<Tuple<int, ConsoleColor, ConsoleColor>> colors = new List<Tuple<int, ConsoleColor, ConsoleColor>>
        {
            new Tuple<int, ConsoleColor, ConsoleColor>(1, ConsoleColor.Gray, ConsoleColor.Black),
            new Tuple<int, ConsoleColor, ConsoleColor>(2, ConsoleColor.Blue, ConsoleColor.Black),
            new Tuple<int, ConsoleColor, ConsoleColor>(3, ConsoleColor.Green, ConsoleColor.Black)
        };

        static void Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            _menu = new Menu();

            _menu.Add("Run Builder", GetComponent);
            _menu.Add("Import Components Recipes", ImportComponentRecipes);
            _menu.Add("Import Buildings Recipes", ImportBuildingRecipes);
            _menu.Add("Import Components", ImportComponents);
            _menu.Add("Export Components", ExportComponents);
            _menu.Add("Exit", () => { Console.WriteLine("Exiting..."); });
            _menu.Display();



        }

        private static void GetComponent()
        {
            int componentId = 0;
            int numberDesired = 0;
            string response = string.Empty;
            do
            {
                Console.Write("Component ID: ");
                response = Console.ReadLine();

                if (!int.TryParse(response, out componentId))
                {
                    Console.WriteLine("Not a number");
                }
                else
                {
                    break;
                }
            } while (componentId == 0 || response.ToLower() != "exit");

            do
            {
                Console.Write("Desired Per Minute: ");
                response = Console.ReadLine();
                if (!int.TryParse(response, out numberDesired))
                {
                    Console.WriteLine("Not a number");
                }
                else
                {
                    break;
                }
            } while (numberDesired == 0 || response.ToLower() != "exit");

            if (componentId != 0 && numberDesired != 0)
            {
                RunBuild(componentId, numberDesired);
            }

            ReShowMenu();
        }

        private static void ImportComponentRecipes()
        {
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");
            var fileName = _config.GetValue<string>("Files:ComponentRecipes");
            var fullPath = Path.Combine(basePath, fileName);
            var importTool = new JsonImport(connectionString);
            importTool.ImportComponentRecipes(fullPath);
            ReShowMenu();
        }

        private static void ImportBuildingRecipes()
        {
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");
            var fileName = _config.GetValue<string>("Files:BuildingRecipes");
            var fullPath = Path.Combine(basePath, fileName);
            var importTool = new JsonImport(connectionString);
            importTool.ImportBuildings(fullPath);
            ReShowMenu();
        }

        private static void ImportComponents()
        {
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");
            var fileName = _config.GetValue<string>("Files:Components");
            var fullPath = Path.Combine(basePath, fileName);
            var importTool = new JsonImport(connectionString);
            importTool.ImportComponents(fullPath);
            ReShowMenu();
        }
        public static void ExportComponents()
        {
            var connectionString = _config.GetValue<string>("ConnectionString");
            var basePath = _config.GetValue<string>("BasePath");
            var fileName = _config.GetValue<string>("Files:Component");
            var fullPath = Path.Combine(basePath, fileName);
            var importTool = new JsonImport(connectionString);
            importTool.ExportComponents(fullPath);
            ReShowMenu();
        }

        private static void RunBuild(int componentId, int numberDesired)
        {
            var connectionString = _config.GetValue<string>("ConnectionString");
            var builder = new Builder(new UnitOfWorkFactory(connectionString));
            try
            {
                var build =
                    builder.CreateBuild(componentId);

                build.DesiredPerMinute = numberDesired;


                PrintBuildResult(build);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


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
            var summaryCount = new SummaryCount();
            CalculateSummary(build.ComponentToBuild, summaryCount);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSummary(summaryCount);
        }
        private static void PrintBuildComponenet(BuildComponent buildComponent, int level)
        {
            var spacesNeeded = level * 5;
            for (int i = 0; i < spacesNeeded; i++)
            {
                Console.Write("-");
            }

            if (verbose)
            {
                Console.Write($"{buildComponent.Recipe.Component.Name} needs {buildComponent.NumberOfBuilders} {buildComponent.Recipe.MachineType}(s) To Produce {buildComponent.ProducedPerMinute} with a build target of {buildComponent.BuildTargetPerMinute}\r\n");
            }
            else
            {
                Console.Write($"{buildComponent.Recipe.Component.Name} needs {buildComponent.NumberOfBuilders} {buildComponent.Recipe.MachineType}(s)\r\n");
            }


            foreach (var buildComponentInputComponent in buildComponent.InputComponents)
            {
                PrintBuildComponenet(buildComponentInputComponent, level + 1);
            }
        }

        private static void CalculateSummary(BuildComponent buildComponent, SummaryCount counts)
        {

            if (counts.MachineCount.ContainsKey(buildComponent.BuilderMachine.MachineType))
            {
                counts.MachineCount[buildComponent.BuilderMachine.MachineType] += buildComponent.NumberOfBuilders;
            }
            else
            {
                counts.MachineCount.Add(buildComponent.BuilderMachine.MachineType, buildComponent.NumberOfBuilders);
            }

            if (buildComponent.Recipe.Component.IsBasic)
            {
                if (counts.BaseItemCount.ContainsKey(buildComponent.Recipe.Component.Name))
                {
                    counts.BaseItemCount[buildComponent.Recipe.Component.Name] += buildComponent.ProducedPerMinute;
                }
                else
                {
                    counts.BaseItemCount.Add(buildComponent.Recipe.Component.Name, buildComponent.ProducedPerMinute);
                }
            }

            foreach (var buildComponentInputComponent in buildComponent.InputComponents)
            {
                CalculateSummary(buildComponentInputComponent, counts);
            }
        }

        private static void PrintSummary(SummaryCount counts)
        {
            Console.WriteLine("------Machine Counts--------");
            foreach (var machine in counts.MachineCount)
            {
                Console.WriteLine($"{machine.Key} : {machine.Value}");
            }
            Console.WriteLine($"\r\n-----Basic Count-----");
            foreach (var baseItem in counts.BaseItemCount)
            {
                Console.WriteLine($"{baseItem.Key} : {baseItem.Value}");
            }
        }

        private static void ReShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Complete");
            Console.ForegroundColor = ConsoleColor.White;
            _menu.Display();
        }
    }
}

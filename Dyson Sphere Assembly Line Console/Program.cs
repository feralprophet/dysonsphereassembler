using System;
using Dyson_Sphere_Assembly_Line_Domain;
using DysonSphereAssembly.DAL.Tools;

namespace Dyson_Sphere_Assembly_Line_Console
{
    class Program
    {
        static void Main(string[] args)
        { 
            var connectionString = "Data Source=localhost;Initial Catalog=DysonSphereAssembler;Integrated Security=True";
            //var importTool = new JsonImport(connectionString);
            //importTool.ImportRecipes("C:\\Repo\\PersonalRepo\\DysonSphereAssembler\\Data\\Components.json");

            var builder = new Builder(new UnitOfWorkFactory(connectionString));
            var build =
            builder.CreateBuild(67);

            Console.WriteLine("Complete");
        }
    }
}

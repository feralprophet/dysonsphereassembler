using System;
using DysonSphereAssembly.DAL.Tools;

namespace Dyson_Sphere_Assembly_Line_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=DysonSphereAssembler;Integrated Security=True";
            var importTool = new JsonImport(connectionString);
            importTool.ImportRecipes("C:\\Repo\\PersonalRepo\\DysonSphereAssembler\\Data\\TestImport.json");

            Console.WriteLine("Complete");
        }
    }
}

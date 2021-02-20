using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DysonSphereAssembly.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DysonSphereAssembly.DAL.Tools
{

    public class RecipeCollection
    {
        public List<RecipeImport> recipes { get; set; }
    }

    public class ComponentCollection
    {
        public List<Component> components { get; set; }
    }

    public class JsonImport
    {
        private readonly string _connectionString;

        public JsonImport(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void ImportComponentRecipes(string path)
        {
            var jsonData = File.ReadAllText(path);

            var result = (RecipeCollection)
                JsonConvert.DeserializeObject(jsonData, typeof(RecipeCollection));
            InsertComponentRecipes(result.recipes);
        }

        public void ImportBuildings(string path)
        {
            var jsonData = File.ReadAllText(path);

            var result = (RecipeCollection)
                JsonConvert.DeserializeObject(jsonData, typeof(RecipeCollection));
            InsertBuildingRecipes(result.recipes);
        }

        public void ImportComponents(string path)
        {
            var jsonData = File.ReadAllText(path);

            var result = (ComponentCollection)
                JsonConvert.DeserializeObject(jsonData, typeof(ComponentCollection));
            InsertComponents(result.components);
        }
        public void ExportComponents(string path)
        {
            using (var context = CreateContext())
            {
                var components = context.Components.ToList();
                var componentCollection = new ComponentCollection();
                componentCollection.components = components;

                var json =
                    JsonConvert.SerializeObject(componentCollection);
                var fullPath =
                    Path.Combine(path, "components.json");

                File.AppendAllText(fullPath, json);
            }
        }

        private void InsertComponentRecipes(List<RecipeImport> recipes)
        {
            using (var context = CreateContext())
            {
                foreach (var recipeImport in recipes)
                {
                    var component = context.Components.First(i => i.Name == recipeImport.ComponentName);
                    var machineType = context.MachineTypes.First(i => i.Name == recipeImport.MachineType);

                    var recipe = new Recipe
                    {
                        Name = component.Name,
                        ComponentId = component.Id,
                        MachineType = machineType.Id,
                        NumberProduced = recipeImport.NumberProduced,
                        TimeToCreate = recipeImport.TimeToCreate,
                        UseByDefault = recipeImport.Default,
                        IsBuilding = false
                    };

                    context.Recipes.Add(recipe);
                    context.SaveChanges();

                    foreach (var input in recipeImport.Inputs)
                    {
                        var inputComponent = context.Components.First(i => i.Name == input.ComponentName);
                        var componentInput = new ComponentInput
                        {
                            AmountNeeded = input.Count,
                            InputComponentId = inputComponent.Id,
                            RecipeId = recipe.Id
                        };
                        context.ComponentInputs.Add(componentInput);
                    }

                    context.SaveChanges();

                    foreach (var additionalOutput in recipeImport.AdditionalOutput)
                    {
                        var outputComponent = context.Components.First(i => i.Name == additionalOutput.ComponentName);
                        var output = new AdditionalOutput
                        {
                            Amount = additionalOutput.Count,
                            ComponentId = outputComponent.Id,
                            RecipeId = recipe.Id
                        };

                        context.AdditionalOutputs.Add(output);
                    }

                    context.SaveChanges();
                }
            }
        }

        private void InsertBuildingRecipes(List<RecipeImport> buildings)
        {
            using (var context = CreateContext())
            {
                foreach (var recipeImport in buildings)
                {
                    var component = context.Components.First(i => i.Name == recipeImport.ComponentName);
                    var machineType = context.MachineTypes.First(i => i.Name == recipeImport.MachineType);

                    var recipe = new Recipe
                    {
                        Name = component.Name,
                        ComponentId = component.Id,
                        MachineType = machineType.Id,
                        NumberProduced = recipeImport.NumberProduced,
                        TimeToCreate = recipeImport.TimeToCreate,
                        UseByDefault = recipeImport.Default,
                        IsBuilding = true
                    };

                    context.Recipes.Add(recipe);
                    context.SaveChanges();

                    foreach (var input in recipeImport.Inputs)
                    {
                        var inputComponent = context.Components.First(i => i.Name == input.ComponentName);
                        var componentInput = new ComponentInput
                        {
                            AmountNeeded = input.Count,
                            InputComponentId = inputComponent.Id,
                            RecipeId = recipe.Id
                        };
                        context.ComponentInputs.Add(componentInput);
                    }

                    context.SaveChanges();

                    foreach (var additionalOutput in recipeImport.AdditionalOutput)
                    {
                        var outputComponent = context.Components.First(i => i.Name == additionalOutput.ComponentName);
                        var output = new AdditionalOutput
                        {
                            Amount = additionalOutput.Count,
                            ComponentId = outputComponent.Id,
                            RecipeId = recipe.Id
                        };

                        context.AdditionalOutputs.Add(output);
                    }

                    context.SaveChanges();
                }
            }
        }

        private void InsertComponents(List<Component> components)
        {
            using (var context = CreateContext())
            {
                context.Components.AddRange(components);
                context.SaveChanges(true);
            }
        }


        private DysonSphereAssemblerContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<DysonSphereAssemblerContext>().UseSqlServer(_connectionString);
            return new DysonSphereAssemblerContext(builder.Options);
        }
    }
}

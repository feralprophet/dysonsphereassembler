using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dyson_Sphere_Assembly_Line_Domain;
using Dyson_Sphere_Assembly_Line_Domain.Repositories;

namespace DysonSphereAssembly.DAL.Repository
{
    public class RecipeRepository: IRecipeRepo
    {
        private readonly DysonSphereAssemblerContext _context;

        public RecipeRepository(DysonSphereAssemblerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ComponentRecipe GetById(int recipeId)
        {
            var dbRecipe = _context.Recipes.Single(i => i.Id == recipeId);
            var dbRecipeInputs = _context.ComponentInputs.Where(i => i.RecipeId == recipeId).ToList();
            var dbRecipeAdditionalOutput = _context.AdditionalOutputs.Where(i => i.RecipeId == recipeId).ToList();

            List<InputComponent> inputComponents = new List<InputComponent>();
            List<OutputComponent> outputComponents = new List<OutputComponent>();

            foreach (var componentInput in dbRecipeInputs)
            {
                
                inputComponents.Add(new InputComponent
                {
                    Component = GetComponentById(componentInput.InputComponentId),
                    AmountNeeded = componentInput.AmountNeeded
                });
            }

            foreach (var additionalOutput in dbRecipeAdditionalOutput)
            {
                outputComponents.Add(new OutputComponent
                {
                    Component = GetComponentById(additionalOutput.ComponentId),
                    Amount = additionalOutput.Amount
                });
            }
            return new ComponentRecipe
            {
                Component = GetComponentById(dbRecipe.ComponentId),
                NumberProduced = dbRecipe.NumberProduced,
                TimeToCreate = dbRecipe.TimeToCreate,
                InputComponents = inputComponents,
                MachineType = (MachineType)dbRecipe.MachineType
            };
        }

        public ComponentRecipe GetDefaultForComponent(int componentId)
        {
            var recipeId = _context.Recipes.First(i => i.UseByDefault && i.ComponentId == componentId).Id;
            return GetById(recipeId);
        }

        private Component GetComponentById(int id)
        {
            var dbComponent = _context.Components.Single(i => i.Id == id);

            return new Component
            {
                Id = dbComponent.Id,
                Name = dbComponent.Name,
                IsBasic = dbComponent.IsBasic,
                IsRaw = dbComponent.IsRaw
            };
        }
    }
}

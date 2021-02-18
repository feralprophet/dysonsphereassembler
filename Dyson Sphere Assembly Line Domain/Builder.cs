using System;
using System.Collections.Generic;
using System.Linq;
using Dyson_Sphere_Assembly_Line_Domain.Repositories;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class Builder
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public Builder(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory ?? throw new ArgumentNullException(nameof(uowFactory));
        }

        public Build CreateBuild(int componentId, int desiredAmount)
        {
            var build = new Build();
            using (var uow = _uowFactory.Create())
            {
                build.ComponentToBuild = CreateBuildComponent(componentId, uow);
            } 

            build.DesiredPerMinute = desiredAmount;
            return build;
        }

        public  Build CreateBuild(int componentId)
        {
            return CreateBuild(componentId, 0);
        }

        private BuildComponent CreateBuildComponent(int componentId, IUnitOfWork uow)
        {
            var recipe = uow.Recipes.GetDefaultForComponent(componentId);
            var machine = uow.Machines.GetByType(recipe.MachineType);

            List<BuildComponent> inputComponents = new List<BuildComponent>();
            foreach (var componentInput in recipe.InputComponents)
            {
                inputComponents.Add(CreateBuildComponent(componentInput.Component.Id,  uow));
            }
            return  new BuildComponent
            {
                Recipe = recipe,
                BuilderMachine = machine,
                InputComponents = inputComponents
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class BuildComponent
    {
        private decimal _buildTargetPerMinute = 0m;
        public decimal BuildTargetPerMinute
        {
            get { return _buildTargetPerMinute;}
            set
            {
                if (value != _buildTargetPerMinute)
                {
                    _buildTargetPerMinute = value;
                    RecalculateInputs();
                }
            }
        }
        public ComponentRecipe Recipe { get; set; }
        public Machine BuilderMachine { get; set; }
        public decimal NumberPerMinuteFromBuilder
        {
            get { return (60 / Recipe.TimeToCreate) * Recipe.NumberProduced * BuilderMachine.ProductionModifier; }
        }
        public decimal NumberOfBuilders
        {
            get { return _buildTargetPerMinute / NumberPerMinuteFromBuilder; }
        }
        public decimal ProducedPerMinute
        {
            get { return Math.Ceiling(NumberOfBuilders) * NumberPerMinuteFromBuilder; }
        }
        public decimal ExcessPerMinute
        {
            get { return ProducedPerMinute - _buildTargetPerMinute; }
        }
        public List<BuildComponent> InputComponents { get; set; } = new List<BuildComponent>();

        public void RecalculateInputs()
        {
            foreach (var inputComponent in InputComponents)
            {
                inputComponent.BuildTargetPerMinute = _buildTargetPerMinute * Recipe.InputComponents.Single(i => i.Component.Id == inputComponent.Recipe.Component.Id).AmountNeeded;
            }
        }

    }
}

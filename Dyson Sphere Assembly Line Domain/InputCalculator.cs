using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class InputCalculator
    {
        public int BeltSpeed { get; set; }
        public decimal MachineModifier { get; set; }
        public decimal RecipeTime { get; set; }
        public decimal InputAmount { get; set; }
        public decimal AmountProduced { get; set; }

        public decimal CalculateMachinesNeeded()
        {
            decimal amountConsumedPerMinute = (60 / (RecipeTime / MachineModifier)) * InputAmount;

            return BeltSpeed / amountConsumedPerMinute;
        }
    }
}

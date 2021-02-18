using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class ComponentRecipe
    {
        public Component Component { get; set; }
        public decimal TimeToCreate { get; set; }
        public int NumberProduced { get; set; }
        public MachineType MachineType { get; set; }
        public List<InputComponent> InputComponents { get; set; }
        public List<OutputComponent> AdditionalOutputComponents { get; set; }
    }
}

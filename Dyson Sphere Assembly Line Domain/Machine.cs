using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class Machine
    {
        public string Name { get; set; }
        public decimal ProductionModifier { get; set; }
        public MachineType MachineType { get; set; }
    }
}

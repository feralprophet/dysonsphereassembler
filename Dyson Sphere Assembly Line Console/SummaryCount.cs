using System;
using System.Collections.Generic;
using System.Text;
using Dyson_Sphere_Assembly_Line_Domain;

namespace Dyson_Sphere_Assembly_Line_Console
{
    public class SummaryCount
    {
        public decimal SmelterCount { get; set; }
        public decimal ChemicalPlant { get; set; }
        public decimal Assembler { get; set; }
        public decimal OilRefinery { get; set; }
        public decimal ParticleCollider { get; set; }
        public decimal MatrixLab { get; set; }
        public Dictionary<string, decimal> BaseItemCount { get; set; } = new Dictionary<string, decimal>();
        public Dictionary<MachineType, decimal> MachineCount { get; set; } = new Dictionary<MachineType, decimal>();
    }
}

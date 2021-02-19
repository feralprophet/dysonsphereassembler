using System;
using System.Collections.Generic;
using System.Text;

namespace DysonSphereAssembly.DAL.Tools
{
    public class RecipeImport
    {
        public string ComponentName { get; set; }
        public bool Default { get; set; }
        public int NumberProduced { get; set; }
        public decimal TimeToCreate { get; set; }
        public string MachineType { get; set; }
        public List<ComponentWithCount> Inputs { get; set; } = new List<ComponentWithCount>();
        public List<ComponentWithCount> AdditionalOutput { get; set; } = new List<ComponentWithCount>();

    }
}

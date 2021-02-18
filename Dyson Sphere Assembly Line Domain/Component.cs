using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBasic { get; set; }
        public bool IsRaw { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DysonSphereAssembly.DAL.Models
{
    [Table("Machines")]
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MachineType { get; set; }
        public decimal ProductionModifier { get; set; }
    }
}

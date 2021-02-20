using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DysonSphereAssembly.DAL.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ComponentId { get; set; }
        public int MachineType { get; set; }
        public decimal TimeToCreate { get; set; }
        public int NumberProduced { get; set; }
        public bool UseByDefault { get; set; }
        public bool IsBuilding { get; set; }
    }
}

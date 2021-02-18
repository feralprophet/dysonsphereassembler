using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DysonSphereAssembly.DAL.Models
{
    [Table("ComponentInputs")]
    public class ComponentInput
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int InputComponentId { get; set; }
        public int AmountNeeded { get; set; }
        public int Version { get; set; }
    }
}

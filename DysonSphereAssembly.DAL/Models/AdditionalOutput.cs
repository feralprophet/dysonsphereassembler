using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DysonSphereAssembly.DAL.Models
{
    [Table("AdditionalOutput")]
    public class AdditionalOutput
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ComponentId { get; set; }
        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DysonSphereAssembly.DAL.Models
{
    [Table("Components")]
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBasic { get; set; }
        public bool IsRaw { get; set; }


    }
}

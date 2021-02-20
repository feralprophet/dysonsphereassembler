using System;
using System.Collections.Generic;
using System.Text;
using DysonSphereAssembly.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DysonSphereAssembly.DAL
{
    public class DysonSphereAssemblerContext: DbContext
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ComponentInput> ComponentInputs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<AdditionalOutput> AdditionalOutputs { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }

        public DysonSphereAssemblerContext(DbContextOptions<DysonSphereAssemblerContext> options) : base(options)
        {

        }
    }
}

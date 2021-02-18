using Dyson_Sphere_Assembly_Line_Domain.Repositories;
using DysonSphereAssembly.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace DysonSphereAssembly.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private DysonSphereAssemblerContext _context;
        public UnitOfWork(string connectionString)
        {
            var configBuilder = new DbContextOptionsBuilder<DysonSphereAssemblerContext>().UseSqlServer(connectionString);
            _context = new DysonSphereAssemblerContext(configBuilder.Options);
            Recipes = new RecipeRepository(_context);
            Components = new ComponentRepository(_context);
            Machines = new MachineRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRecipeRepo Recipes { get; set; }
        public IComponentRepo Components { get; set; }
        public IMachineRepo Machines { get; set; }
    }
}

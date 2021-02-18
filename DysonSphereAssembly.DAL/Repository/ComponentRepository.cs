using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dyson_Sphere_Assembly_Line_Domain;
using Dyson_Sphere_Assembly_Line_Domain.Repositories;

namespace DysonSphereAssembly.DAL.Repository
{
    public class ComponentRepository : IComponentRepo
    {
        private readonly DysonSphereAssemblerContext _context;

        public ComponentRepository(DysonSphereAssemblerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Component GetById(int Id)
        {
            var dbComponent = _context.Components.Single(i => i.Id == Id);

            return new Component
            {
                Name = dbComponent.Name,
                IsBasic = dbComponent.IsBasic,
                Id = dbComponent.Id,
                IsRaw = dbComponent.IsRaw
            };
        }
    }
}

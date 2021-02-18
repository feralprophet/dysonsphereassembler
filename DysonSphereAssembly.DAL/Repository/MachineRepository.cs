using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dyson_Sphere_Assembly_Line_Domain;
using Dyson_Sphere_Assembly_Line_Domain.Repositories;

namespace DysonSphereAssembly.DAL.Repository
{
    public class MachineRepository : IMachineRepo
    {
        private readonly DysonSphereAssemblerContext _context;

        public MachineRepository(DysonSphereAssemblerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Machine GetById(int id)
        {
            var dbMachine = _context.Machines.Single(i => i.Id == id);

            return new Machine
            {
                Name = dbMachine.Name,
                MachineType = (MachineType) dbMachine.MachineType,
                ProductionModifier = dbMachine.ProductionModifier
            };
        }

        public Machine GetByType(MachineType machineType)
        {
            var dbMachine = _context.Machines.First(i => i.MachineType == (int) machineType);
            return new Machine
            {
                Name = dbMachine.Name,
                MachineType = (MachineType)dbMachine.MachineType,
                ProductionModifier = dbMachine.ProductionModifier
            };
        }
    }
}

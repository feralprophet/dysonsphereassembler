using System;
using System.Collections.Generic;
using System.Text;
using Dyson_Sphere_Assembly_Line_Domain.Repositories;
using DysonSphereAssembly.DAL;

namespace Dyson_Sphere_Assembly_Line_Console
{
    public class UnitOfWorkFactory: IUnitOfWorkFactory
    {
        private readonly string _connectionString;

        public UnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_connectionString);
        }
    }
}

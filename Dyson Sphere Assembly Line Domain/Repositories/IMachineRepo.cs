using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain.Repositories
{ 
    public interface IMachineRepo
    {
        Machine GetById(int id);
        Machine GetByType(MachineType machineType);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IRecipeRepo Recipes { get; set; }
        IComponentRepo Components { get; set; }
        IMachineRepo Machines { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain.Repositories
{
    public interface IComponentRepo
    {
        Component GetById(int Id);
    }
}

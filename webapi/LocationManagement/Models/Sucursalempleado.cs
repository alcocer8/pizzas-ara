﻿using System;
using System.Collections.Generic;

namespace LocationManagement.Models;

public partial class Sucursalempleado
{
    public int Idsucursalempleado { get; set; }

    public int? Idsucursal { get; set; }

    public int? Idempleado { get; set; }

    public virtual Empleado? IdempleadoNavigation { get; set; }

    public virtual Sucursal? IdsucursalNavigation { get; set; }
}

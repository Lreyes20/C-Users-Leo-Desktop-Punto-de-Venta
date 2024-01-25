using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvUbicacionSalon
{
    public string IdMesa { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }
}

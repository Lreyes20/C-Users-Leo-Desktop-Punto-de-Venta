using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvDependiente
{
    public int IdDependiente { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }
}

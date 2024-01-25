using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvCliente
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public decimal? Teloficina { get; set; }

    public decimal? Telfax { get; set; }

    public decimal? Cuentabanco { get; set; }
}

using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvMovimiento
{
    public decimal IdMovimientos { get; set; }

    public int? NumDocumento { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fechamov { get; set; }

    public int? Idtipoajuste { get; set; }
}

using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvDetalleMovimiento
{
    public int IdDocumento { get; set; }

    public int IdArticulo { get; set; }

    public decimal? Cantidad { get; set; }
}

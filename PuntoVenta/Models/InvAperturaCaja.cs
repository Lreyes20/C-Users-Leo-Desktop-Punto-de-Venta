using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvAperturaCaja
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Montocxc { get; set; }
}

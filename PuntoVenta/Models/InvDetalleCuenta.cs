using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvDetalleCuenta
{
    public decimal IdCuenta { get; set; }

    public decimal IdLinea { get; set; }

    public decimal? IdCodarticulo { get; set; }

    public decimal? Unidamedidad { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Costoventa { get; set; }

    public int? Impuestoventa { get; set; }

    public decimal? Costopromedio { get; set; }

    public int? Descuento { get; set; }

    public bool? Cortesia { get; set; }

    public string? Tipo { get; set; }

    public string? Opctipo { get; set; }
}

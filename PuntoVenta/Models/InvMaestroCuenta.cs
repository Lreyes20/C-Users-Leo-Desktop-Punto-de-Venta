using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvMaestroCuenta
{
    public decimal IdCuenta { get; set; }

    public DateTime IdFecha { get; set; }

    public string IdClienteUbicacion { get; set; } = null!;

    public int? IdDependiente { get; set; }

    public int? IdFactura { get; set; }

    public decimal? Montopago { get; set; }

    public decimal? Montoefectivo { get; set; }

    public decimal? Montotarjeta { get; set; }

    public int? ImpuestoServicio { get; set; }

    public decimal? Descuento { get; set; }

    public int? Estado { get; set; }

    public int? IdTipoPago { get; set; }
}

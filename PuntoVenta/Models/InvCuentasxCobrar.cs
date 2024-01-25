using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvCuentasxCobrar
{
    public int Idcuenta { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public bool? Estado { get; set; }
}

using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvParametro
{
    public int IdParametro { get; set; }

    public string? Descripcion { get; set; }

    public int? Valorparam { get; set; }

    public decimal? Valorparam2 { get; set; }

    public string? Valorparam3 { get; set; }
}

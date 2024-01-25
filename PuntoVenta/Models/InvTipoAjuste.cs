using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvTipoAjuste
{
    public int Id { get; set; }

    public int? IdTipocuenta { get; set; }

    public string? Nombre { get; set; }
}

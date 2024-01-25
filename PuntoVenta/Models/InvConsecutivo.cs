using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvConsecutivo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? Consecutivo { get; set; }
}

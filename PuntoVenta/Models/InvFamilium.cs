using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvFamilium
{
    public int IdFamilia { get; set; }

    public string? Descripcion { get; set; }

    public string? Informacion { get; set; }

    public virtual ICollection<InvArticulo> InvArticulos { get; set; } = new List<InvArticulo>();
}

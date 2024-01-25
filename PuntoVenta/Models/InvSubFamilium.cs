using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvSubFamilium
{
    public int IdSubfamilia { get; set; }

    public string? Descripcion { get; set; }

    public string? Informacion { get; set; }

    public int? IdFamilia { get; set; }

    public virtual ICollection<InvArticulo> InvArticulos { get; set; } = new List<InvArticulo>();
}

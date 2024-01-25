using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvProvincia
{
    public decimal Id { get; set; }

    public string? Descripción { get; set; }

    public virtual ICollection<InvProveedore> InvProveedores { get; set; } = new List<InvProveedore>();
}

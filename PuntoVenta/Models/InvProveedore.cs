using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvProveedore
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Contacto { get; set; }

    public string? Cedula { get; set; }

    public string? Direccion { get; set; }

    public decimal? Provincia { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public DateTime? Fechainiciorelacion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telfax { get; set; }

    public string? Telcelular { get; set; }

    public string? Apartadopostal { get; set; }

    public virtual ICollection<InvArticulo> InvArticulos { get; set; } = new List<InvArticulo>();

    public virtual InvProvincia? ProvinciaNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvArticulo
{
    public decimal Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdUnidadMedida { get; set; }

    public int? IdFamilia { get; set; }

    public int? IdUbicacion { get; set; }

    public int? IdProveedor { get; set; }

    public int? PesoBruto { get; set; }

    public decimal? CantExistencia { get; set; }

    public int? CantReservado { get; set; }

    public int? Cantpedidominimo { get; set; }

    public int? Cantareponer { get; set; }

    public bool? IndNumeroserie { get; set; }

    public bool? IndFraccionado { get; set; }

    public bool? IndConsignacion { get; set; }

    public DateTime? IndFechavencimiento { get; set; }

    public bool? IndVentapeso { get; set; }

    public bool? IndCompuesto { get; set; }

    public DateTime? FechaultimaCompra { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? Costopromedio { get; set; }

    public decimal? Precio1 { get; set; }

    public decimal? Precio2 { get; set; }

    public decimal? Precio3 { get; set; }

    public decimal? Montoimpuesto { get; set; }

    public bool? IndInventario { get; set; }

    public decimal? IntDescuento { get; set; }

    public int? IdSubfamilia { get; set; }

    public virtual InvFamilium? IdFamiliaNavigation { get; set; }

    public virtual InvProveedore? IdProveedorNavigation { get; set; }

    public virtual InvSubFamilium? IdSubfamiliaNavigation { get; set; }
}

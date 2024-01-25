using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvCierreCaja
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? MontoEfectivo { get; set; }

    public decimal? MontoTarjetas { get; set; }

    public decimal? MontoCuentascobar { get; set; }

    public decimal? MontoGastos { get; set; }

    public decimal? MontoOtrosingresos { get; set; }

    public decimal? MontoImpservicio { get; set; }

    public decimal? MontoTrabajo { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? Montocxc { get; set; }

    public decimal? Montodesc { get; set; }

    public decimal? Montosinpe { get; set; }
}

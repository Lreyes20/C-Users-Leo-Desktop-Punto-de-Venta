using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvArticulosCompuesto
{
    public decimal IdArticulo { get; set; }

    public decimal? Idartidepen { get; set; }

    public decimal? Cantidadactual { get; set; }

    public decimal? Cantestablecida { get; set; }
}

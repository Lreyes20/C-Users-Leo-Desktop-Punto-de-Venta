using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class InvUsuario
{
    public string Usuario { get; set; } = null!;

    public string? Contraseña { get; set; }

    public string? Perfil { get; set; }

    public bool? IndEstado { get; set; }
}

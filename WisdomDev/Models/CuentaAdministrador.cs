using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class CuentaAdministrador
{
    public int IdCuentaAdministrador { get; set; }

    public int? IdUsuarioAdministrador { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public virtual UsuarioAdministrador? IdUsuarioAdministradorNavigation { get; set; }
}

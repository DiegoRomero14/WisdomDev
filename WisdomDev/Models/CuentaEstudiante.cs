using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class CuentaEstudiante
{
    public int IdCuentaEstudiante { get; set; }

    public int? IdUsuarioEstudiante { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<CuentaCurso> CuentaCursos { get; set; } = new List<CuentaCurso>();

    public virtual UsuarioEstudiante? IdUsuarioEstudianteNavigation { get; set; }
}

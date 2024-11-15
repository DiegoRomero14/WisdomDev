using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class CuentaCurso
{
    public int IdCuentaCurso { get; set; }

    public int? IdCuentaEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public string? Estado { get; set; }

    public int? Progreso { get; set; }

    public virtual CuentaEstudiante? IdCuentaEstudianteNavigation { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }
}

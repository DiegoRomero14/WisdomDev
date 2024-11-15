using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int? IdCiclo { get; set; }

    public string? NombreCurso { get; set; }

    public string? CargaHoraria { get; set; }

    public DateOnly? UltimaActualizacion { get; set; }

    public string? Autor { get; set; }

    public int? Alumnos { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CuentaCurso> CuentaCursos { get; set; } = new List<CuentaCurso>();

    public virtual Ciclo? IdCicloNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class Ciclo
{
    public int IdCiclo { get; set; }

    public string? NombreCiclo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}

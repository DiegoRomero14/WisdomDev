using System;
using System.Collections.Generic;

namespace WisdomDev.Models;

public partial class UsuarioEstudiante
{
    public int IdUsuarioEstudiante { get; set; }

    public string? DocumentoIdentificacion { get; set; }

    public string? NombreCompleto { get; set; }

    public int? Edad { get; set; }

    public string? Telefono { get; set; }

    public string? Genero { get; set; }

    public string? Pais { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<CuentaEstudiante> CuentaEstudiantes { get; set; } = new List<CuentaEstudiante>();
}

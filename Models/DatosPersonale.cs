using System;
using System.Collections.Generic;

namespace practica04.Models;

public partial class DatosPersonale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Celular { get; set; }

    public string? Carnet { get; set; }

    public string? Direccion { get; set; }
}

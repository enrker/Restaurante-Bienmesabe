using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string NumeroTelf { get; set; } = null!;

    public virtual ICollection<SuministroProveedor> SuministroProveedors { get; set; } = new List<SuministroProveedor>();
}

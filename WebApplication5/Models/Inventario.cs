using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int IdSuministro { get; set; }

    public int Cantidad { get; set; }

    public virtual Suministro IdSuministroNavigation { get; set; } = null!;
}

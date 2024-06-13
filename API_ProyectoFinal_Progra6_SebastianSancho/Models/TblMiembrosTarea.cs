using System;
using System.Collections.Generic;

namespace API_ProyectoFinal_Progra6_SebastianSancho.Models;

public partial class TblMiembrosTarea
{
    public int MiembroId { get; set; }

    public int TareaId { get; set; }

    public virtual TblMiembro Miembro { get; set; } = null!;

    public virtual TblTarea Tarea { get; set; } = null!;
}

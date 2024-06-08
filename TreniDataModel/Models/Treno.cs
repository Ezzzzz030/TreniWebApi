using System;
using System.Collections.Generic;

namespace TreniDataModel.Models;

public partial class Treno
{
    public int Id { get; set; }

    public string? Linea { get; set; }

    public TimeOnly OrarioPartenza { get; set; }

    public TimeOnly OrarioArrivo { get; set; }
}

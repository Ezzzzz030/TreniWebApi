using System;
using System.Collections.Generic;

namespace TreniDataModel.Models;

public partial class Stazione
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Indirizzo { get; set; }
}

using System;
using System.Collections.Generic;

namespace TreniDataModel.Models;

public partial class TrattaTestum
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<TrattaRiga> TrattaRigas { get; set; } = new List<TrattaRiga>();
}

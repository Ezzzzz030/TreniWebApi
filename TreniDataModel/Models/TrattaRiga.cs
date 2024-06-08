using System;
using System.Collections.Generic;

namespace TreniDataModel.Models;

public partial class TrattaRiga
{
    public int IdTratta { get; set; }

    public int Sequenza { get; set; }

    public int IdStazione { get; set; }

    public TimeOnly? OrarioPartenza { get; set; }

    public TimeOnly? OrarioArrivo { get; set; }

    public virtual TrattaTestum IdTrattaNavigation { get; set; } = null!;
}

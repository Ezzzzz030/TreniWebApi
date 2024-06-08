using System;
using System.Collections.Generic;

namespace TreniDataModel.Models;

public partial class Utente
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public bool IsAdmin { get; set; }
}

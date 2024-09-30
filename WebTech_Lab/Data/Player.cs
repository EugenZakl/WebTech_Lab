using System;
using System.Collections.Generic;

namespace WebTech_Lab.Data;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int PhotoId { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual Photo Photo { get; set; } = null!;
}

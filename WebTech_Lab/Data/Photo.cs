using System;
using System.Collections.Generic;

namespace WebTech_Lab.Data;

public partial class Photo
{
    public int PhotoId { get; set; }

    public string? PhotoName { get; set; }

    public string? PhotoUrl { get; set; }

    public string? PhotoBackgroundUrl { get; set; }


    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    public virtual ICollection<Enemy> Enemies { get; set; } = new List<Enemy>();


}

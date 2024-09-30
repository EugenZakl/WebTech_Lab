using System;
using System.Collections.Generic;

namespace WebTech_Lab.Data;

public partial class EnemyType
{
    public int EnemyTypeId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Enemy> Enemies { get; set; } = new List<Enemy>();
}

using System;
using System.Collections.Generic;

namespace WebTech_Lab.Data;

public partial class Enemy
{
    public int EnemyId { get; set; }

    public string? EnemyName { get; set; }

    public string? EnemyDescription { get; set; }

    public string? EnemyHealth { get; set; }

    public string? EnemyDamage { get; set; }

    public int? EnemyTypeId { get; set; }

    public int PhotoId { get; set; }


    public virtual EnemyType? EnemyType { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual Photo Photo { get; set; } = null!;


}

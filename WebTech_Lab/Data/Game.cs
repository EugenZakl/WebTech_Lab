using System;
using System.Collections.Generic;

namespace WebTech_Lab.Data;

public partial class Game
{
    public int GameId { get; set; }

    public string? GameName { get; set; }

    public string? GameDiscription { get; set; }

    public int? PlayerId { get; set; }

    public int? EnemyId { get; set; }

    public virtual Enemy? Enemy { get; set; }

    public virtual Player? Player { get; set; }
}

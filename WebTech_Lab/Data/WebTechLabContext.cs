using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebTech_Lab.Data;

public partial class WebTechLabContext : DbContext
{
    public WebTechLabContext()
    {
    }

    public WebTechLabContext(DbContextOptions<WebTechLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Enemy> Enemies { get; set; }

    public virtual DbSet<EnemyType> EnemyTypes { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Player> Players { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

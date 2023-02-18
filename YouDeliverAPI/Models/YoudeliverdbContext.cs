using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YouDeliverAPI.Models;

public partial class YoudeliverdbContext : DbContext
{
    public YoudeliverdbContext()
    {
    }

    public YoudeliverdbContext(DbContextOptions<YoudeliverdbContext> options)
        : base(options)
    {
    }

    public DbSet<TUsers> TUsers { get; set; }
    public DbSet<TUserInfo> TUserInfo { get; set; }
    public DbSet<TDelivery> TDelivery { get; set; }
    public DbSet<TCart> TCart { get; set; }
    public DbSet<TProducts> TProducts { get; set; }
    public DbSet<TPurchase> TPurchase { get; set; }
    public DbSet<TBusiness> TBusiness { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

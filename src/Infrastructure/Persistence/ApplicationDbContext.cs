﻿using DesafioBackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioBackendAPI.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Person> Person { get; set; }
	public DbSet<Pedidos> Pedidos{ get; set; }
	public DbSet<EstadoDelPedido> EstadoDelPedido { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

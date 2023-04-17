using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Entities;
using Vectra.Avaliacao.Backend.Interfaces;

namespace Vectra.Avaliacao.Backend.Context
{
    public class EFContext : DbContext, IEFContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
            modelBuilder.Entity<Conta>().HasData(new {
                Id = 1,
                Agencia = "9237",
                Numero = "33521-5",
                Cliente = "Cliente 1",
                Saldo = 0.1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            modelBuilder.Entity<Conta>().HasData(new
            {
                Id = 2,
                Agencia = "9237",
                Numero = "33521-5",
                Cliente = "Cliente 2",
                Saldo = 0.1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

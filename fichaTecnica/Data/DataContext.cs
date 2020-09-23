using fichaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace fichaTecnica.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<FichaTecnica> FichaTecnicas { get; set; }
        public DbSet<ItemInsumo> ItemInsumos { get; set; }
        public DbSet<FichaTecnicaInsumo> FichaTecnicaInsumos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

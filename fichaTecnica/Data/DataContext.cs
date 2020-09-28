using fichaTecnica.Data.Enums;
using fichaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(250)");
            }
            modelBuilder.Entity<FichaTecnica>(x =>
            {
                x.ToTable("FichaTecnicas");
                x.HasKey(y => y.Id);
                x.Property(y => y.DescricaoDaFichaTecnica).IsRequired();
                x.Property(y => y.Categoria).IsRequired();
                x.Property(y => y.RendimentoDaPorcao).IsRequired();
            });

            modelBuilder.Entity<ItemInsumo>(x =>
            {
                x.ToTable("ItemInsumos");
                x.HasKey(y => y.Id);
                x.Property(y => y.DescricaoItemInsumo).IsRequired();
                x.Property(y => y.Quantidade).IsRequired();
                x.Property(y => y.TipoDeUnidadeDeMedida)
                 .HasConversion(s => s.ToString(),
                  e => Enum.Parse<TipoDeUnidadeDeMedida>(e));
                x.Property(y => y.CustoUnitario).IsRequired();
                x.Property(y => y.CustoTotal).IsRequired();
            });
        }
    }
}

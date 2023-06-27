using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiMrROBOT.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<carrito> carrito { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<detalle_venta> detalle_venta { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<departament> departament { get; set; }
        public virtual DbSet<district> district { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<detalle_venta>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<marca>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<producto>()
                .Property(e => e.RutaImagen)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.NombreImagen)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.MontoTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<venta>()
                .Property(e => e.Contacto)
                .IsUnicode(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.IdTransaccion)
                .IsUnicode(false);

            modelBuilder.Entity<departament>()
                .Property(e => e.IdDepartement)
                .IsUnicode(false);

            modelBuilder.Entity<departament>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.IdDistrict)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.IdDepartment)
                .IsUnicode(false);

            modelBuilder.Entity<provincia>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<provincia>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<provincia>()
                .Property(e => e.IdDepartment)
                .IsUnicode(false);
        }
    }
}

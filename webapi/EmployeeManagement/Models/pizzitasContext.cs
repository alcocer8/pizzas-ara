using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.Models
{
    public partial class pizzitasContext : DbContext
    {
        public pizzitasContext()
        {
        }

        public pizzitasContext(DbContextOptions<pizzitasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detallesorden> Detallesordens { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<Sucursalempleado> Sucursalempleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("EmployeeDBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Idcargo)
                    .HasName("cargo_pkey");

                entity.ToTable("cargo");

                entity.Property(e => e.Idcargo).HasColumnName("idcargo");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Idciudad)
                    .HasName("ciudad_pkey");

                entity.ToTable("ciudad");

                entity.Property(e => e.Idciudad).HasColumnName("idciudad");

                entity.Property(e => e.Nombreciudad).HasColumnName("nombreciudad");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("cliente_pkey");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Calle)
                    .HasMaxLength(256)
                    .HasColumnName("calle");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(256)
                    .HasColumnName("colonia");

                entity.Property(e => e.Cp)
                    .HasMaxLength(10)
                    .HasColumnName("cp");

                entity.Property(e => e.Idciudad).HasColumnName("idciudad");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(64)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Nexterior).HasColumnName("nexterior");

                entity.Property(e => e.Ninterior).HasColumnName("ninterior");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Referencias).HasColumnName("referencias");

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idciudad)
                    .HasConstraintName("cliente_idciudad_fkey");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("cliente_idestado_fkey");

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idmunicipio)
                    .HasConstraintName("cliente_idmunicipio_fkey");
            });

            modelBuilder.Entity<Detallesorden>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("detallesorden");

                entity.Property(e => e.Iddetalles)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("iddetalles");

                entity.Property(e => e.Idorden).HasColumnName("idorden");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdordenNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idorden)
                    .HasConstraintName("detallesorden_idorden_fkey");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("detallesorden_idproducto_fkey");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("empleado_pkey");

                entity.ToTable("empleado");

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.Property(e => e.Celular)
                    .HasMaxLength(16)
                    .HasColumnName("celular");

                entity.Property(e => e.Idcargo).HasColumnName("idcargo");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(64)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("empleado_idcargo_fkey");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("estado_pkey");

                entity.ToTable("estado");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Nombreestado).HasColumnName("nombreestado");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.Idmunicipio)
                    .HasName("municipio_pkey");

                entity.ToTable("municipio");

                entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.Idorden)
                    .HasName("orden_pkey");

                entity.ToTable("orden");

                entity.Property(e => e.Idorden).HasColumnName("idorden");

                entity.Property(e => e.Fecha)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("orden_idcliente_fkey");

                entity.HasOne(d => d.IdsucursalNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Idsucursal)
                    .HasConstraintName("orden_idsucursal_fkey");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("producto_pkey");

                entity.ToTable("producto");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Precio)
                    .HasPrecision(5, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Idsucursal)
                    .HasName("sucursal_pkey");

                entity.ToTable("sucursal");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.Property(e => e.Calle)
                    .HasMaxLength(256)
                    .HasColumnName("calle");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(256)
                    .HasColumnName("colonia");

                entity.Property(e => e.Cp)
                    .HasMaxLength(10)
                    .HasColumnName("cp");

                entity.Property(e => e.Idciudad).HasColumnName("idciudad");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Nexterior).HasColumnName("nexterior");

                entity.Property(e => e.Ninterior).HasColumnName("ninterior");

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.Idciudad)
                    .HasConstraintName("sucursal_idciudad_fkey");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("sucursal_idestado_fkey");

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.Idmunicipio)
                    .HasConstraintName("sucursal_idmunicipio_fkey");
            });

            modelBuilder.Entity<Sucursalempleado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sucursalempleado");

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("sucursalempleado_idempleado_fkey");

                entity.HasOne(d => d.IdsucursalNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idsucursal)
                    .HasConstraintName("sucursalempleado_idsucursal_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

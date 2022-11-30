using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DetallesOrdenManagement.Models.entities;

public partial class PizzitasContext : DbContext
{
    public PizzitasContext()
    {
    }

    public PizzitasContext(DbContextOptions<PizzitasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Condicion> Condicions { get; set; }

    public virtual DbSet<Detallesorden> Detallesordens { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Sucursalempleado> Sucursalempleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;port=5432;username=lorenzo;password=1234;database=pizzitas");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("cargo_pkey");

            entity.ToTable("cargo");

            entity.Property(e => e.Idcargo).HasColumnName("idcargo");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Idciudad).HasName("ciudad_pkey");

            entity.ToTable("ciudad");

            entity.Property(e => e.Idciudad).HasColumnName("idciudad");
            entity.Property(e => e.Nombreciudad).HasColumnName("nombreciudad");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("cliente_pkey");

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
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
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
            entity.Property(e => e.Pass).HasColumnName("pass");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Referencias).HasColumnName("referencias");

            entity.HasOne(d => d.IdciudadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idciudad)
                .HasConstraintName("cliente_idciudad_fkey");

            entity.HasOne(d => d.IdestadoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idestado)
                .HasConstraintName("cliente_idestado_fkey");

            entity.HasOne(d => d.IdmunicipioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idmunicipio)
                .HasConstraintName("cliente_idmunicipio_fkey");
        });

        modelBuilder.Entity<Condicion>(entity =>
        {
            entity.HasKey(e => e.Idcondicion).HasName("condicion_pkey");

            entity.ToTable("condicion");

            entity.Property(e => e.Idcondicion).HasColumnName("idcondicion");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Detallesorden>(entity =>
        {
            entity.HasKey(e => e.Iddetalles).HasName("detallesorden_pkey");

            entity.ToTable("detallesorden");

            entity.Property(e => e.Iddetalles).HasColumnName("iddetalles");
            entity.Property(e => e.Idorden).HasColumnName("idorden");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdordenNavigation).WithMany(p => p.Detallesordens)
                .HasForeignKey(d => d.Idorden)
                .HasConstraintName("detallesorden_idorden_fkey");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Detallesordens)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("detallesorden_idproducto_fkey");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("empleado_pkey");

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
            entity.Property(e => e.Pass).HasColumnName("pass");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");

            entity.HasOne(d => d.IdcargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcargo)
                .HasConstraintName("empleado_idcargo_fkey");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Idestado).HasName("estado_pkey");

            entity.ToTable("estado");

            entity.Property(e => e.Idestado).HasColumnName("idestado");
            entity.Property(e => e.Nombreestado).HasColumnName("nombreestado");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Idmunicipio).HasName("municipio_pkey");

            entity.ToTable("municipio");

            entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Idorden).HasName("orden_pkey");

            entity.ToTable("orden");

            entity.Property(e => e.Idorden).HasColumnName("idorden");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idcondicion).HasColumnName("idcondicion");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("orden_idcliente_fkey");

            entity.HasOne(d => d.IdcondicionNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.Idcondicion)
                .HasConstraintName("orden_idcondicion_fkey");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("orden_idsucursal_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("producto_pkey");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(64)
                .HasColumnName("descripcion");
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
            entity.HasKey(e => e.Idsucursal).HasName("sucursal_pkey");

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

            entity.HasOne(d => d.IdciudadNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.Idciudad)
                .HasConstraintName("sucursal_idciudad_fkey");

            entity.HasOne(d => d.IdestadoNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.Idestado)
                .HasConstraintName("sucursal_idestado_fkey");

            entity.HasOne(d => d.IdmunicipioNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.Idmunicipio)
                .HasConstraintName("sucursal_idmunicipio_fkey");
        });

        modelBuilder.Entity<Sucursalempleado>(entity =>
        {
            entity.HasKey(e => e.Idsucursalempleado).HasName("sucursalempleado_pkey");

            entity.ToTable("sucursalempleado");

            entity.Property(e => e.Idsucursalempleado).HasColumnName("idsucursalempleado");
            entity.Property(e => e.Idempleado).HasColumnName("idempleado");
            entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

            entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Sucursalempleados)
                .HasForeignKey(d => d.Idempleado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sucursalempleado_idempleado_fkey");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Sucursalempleados)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("sucursalempleado_idsucursal_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

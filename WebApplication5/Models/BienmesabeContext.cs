using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

public partial class BienmesabeContext : DbContext
{
    public BienmesabeContext()
    {
    }

    public BienmesabeContext(DbContextOptions<BienmesabeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Jornadum> Jornada { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoIngrediente> ProductoIngredientes { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Suministro> Suministros { get; set; }

    public virtual DbSet<SuministroProveedor> SuministroProveedors { get; set; }

    public virtual DbSet<TipoConsumo> TipoConsumos { get; set; }

    public virtual DbSet<TipoIngrediente> TipoIngredientes { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<VentaProducto> VentaProductos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263. //
        //=> optionsBuilder.UseSqlServer("server=ENRKER\\SQLEXPRESS; database=Bienmesabe; integrated security=true; Encrypt=False; TrustServerCertificate=True;");//

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__D3C09EC5AC5A9A23");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo)
                .ValueGeneratedNever()
                .HasColumnName("id_cargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__677F38F582592DCC");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__id_empl__5AEE82B9");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__88B5139461F7F16B");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("id_empleado");
            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__id_car__571DF1D5");

            entity.HasOne(d => d.IdJornadaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdJornada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__id_jor__5812160E");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__id_per__5629CD9C");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__6C08ED53DEAF450C");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura)
                .ValueGeneratedNever()
                .HasColumnName("id_factura");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipo_pago");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.NumeroFactura).HasColumnName("numero_factura");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__id_empl__6B24EA82");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__id_tipo__6A30C649");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Factura__id_vent__693CA210");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("PK__Ingredie__3F505D45FA3EF1D8");

            entity.ToTable("Ingrediente");

            entity.Property(e => e.IdIngrediente)
                .ValueGeneratedNever()
                .HasColumnName("id_ingrediente");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdSuministro).HasColumnName("id_suministro");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

            entity.HasOne(d => d.IdSuministroNavigation).WithMany(p => p.Ingredientes)
                .HasForeignKey(d => d.IdSuministro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ingredien__id_su__4BAC3F29");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Ingredientes)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ingredien__id_ti__4AB81AF0");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__Inventar__013AEB51EB0B18B9");

            entity.ToTable("Inventario");

            entity.Property(e => e.IdInventario)
                .ValueGeneratedNever()
                .HasColumnName("id_inventario");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdSuministro).HasColumnName("id_suministro");

            entity.HasOne(d => d.IdSuministroNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdSuministro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__id_su__412EB0B6");
        });

        modelBuilder.Entity<Jornadum>(entity =>
        {
            entity.HasKey(e => e.IdJornada).HasName("PK__Jornada__6BD46D1A0290BA03");

            entity.Property(e => e.IdJornada)
                .ValueGeneratedNever()
                .HasColumnName("id_jornada");
            entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__68A1D9DBF737EAE8");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu)
                .ValueGeneratedNever()
                .HasColumnName("id_menu");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu__id_product__45F365D3");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__228148B04F2F360C");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("id_persona");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido_materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido_paterno");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NumeroTelf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_telf");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("segundo_nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0D11725FE4");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<ProductoIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdProductoIngrediente).HasName("PK__Producto__B92BCB1DA20E9F6B");

            entity.ToTable("Producto_ingrediente");

            entity.Property(e => e.IdProductoIngrediente)
                .ValueGeneratedNever()
                .HasColumnName("id_producto_ingrediente");
            entity.Property(e => e.IdIngrediente).HasColumnName("id_ingrediente");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdIngredienteNavigation).WithMany(p => p.ProductoIngredientes)
                .HasForeignKey(d => d.IdIngrediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto___id_in__4F7CD00D");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoIngredientes)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto___id_pr__4E88ABD4");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE28EFDF0D83");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor)
                .ValueGeneratedNever()
                .HasColumnName("id_proveedor");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroTelf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_telf");
        });

        modelBuilder.Entity<Suministro>(entity =>
        {
            entity.HasKey(e => e.IdSuministro).HasName("PK__Suminist__ABFE9BD1A2EEFF3B");

            entity.ToTable("Suministro");

            entity.Property(e => e.IdSuministro)
                .ValueGeneratedNever()
                .HasColumnName("id_suministro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
        });

        modelBuilder.Entity<SuministroProveedor>(entity =>
        {
            entity.HasKey(e => e.IdSuministroProveedor).HasName("PK__Suminist__FF2D5680BB88BD6F");

            entity.ToTable("Suministro_proveedor");

            entity.Property(e => e.IdSuministroProveedor)
                .ValueGeneratedNever()
                .HasColumnName("id_suministro_proveedor");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdSuministro).HasColumnName("id_suministro");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.SuministroProveedors)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Suministr__id_pr__3D5E1FD2");

            entity.HasOne(d => d.IdSuministroNavigation).WithMany(p => p.SuministroProveedors)
                .HasForeignKey(d => d.IdSuministro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Suministr__id_su__3E52440B");
        });

        modelBuilder.Entity<TipoConsumo>(entity =>
        {
            entity.HasKey(e => e.IdTipoConsumo).HasName("PK__Tipo_con__F0D077380123E72C");

            entity.ToTable("Tipo_consumo");

            entity.Property(e => e.IdTipoConsumo)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_consumo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipo_ing__CF901089CE3D786D");

            entity.ToTable("Tipo_ingrediente");

            entity.Property(e => e.IdTipo)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("PK__Tipo_pag__F7E781E5150EF4A1");

            entity.ToTable("Tipo_pago");

            entity.Property(e => e.IdTipoPago)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_pago");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<VentaProducto>(entity =>
        {
            entity.HasKey(e => e.IdVentaProducto).HasName("PK__Venta_pr__C1AE0FA7678B87BF");

            entity.ToTable("Venta_producto");

            entity.Property(e => e.IdVentaProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_venta_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentaProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta_pro__id_pr__6477ECF3");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaProductos)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta_pro__id_ve__6383C8BA");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__459533BF1C3AA02B");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedNever()
                .HasColumnName("id_venta");
            entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta");
            entity.Property(e => e.HoraVenta).HasColumnName("hora_venta");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdTipoConsumo).HasColumnName("id_tipo_consumo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__id_client__5FB337D6");

            entity.HasOne(d => d.IdTipoConsumoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoConsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__id_tipo_c__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

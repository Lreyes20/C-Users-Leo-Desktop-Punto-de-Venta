using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PuntoVenta.Models;

public partial class InventarioPuntoventaContext : DbContext
{
    public InventarioPuntoventaContext()
    {
    }

    public InventarioPuntoventaContext(DbContextOptions<InventarioPuntoventaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvAperturaCaja> InvAperturaCajas { get; set; }

    public virtual DbSet<InvArticulo> InvArticulos { get; set; }

    public virtual DbSet<InvArticulosCompuesto> InvArticulosCompuestos { get; set; }

    public virtual DbSet<InvCierreCaja> InvCierreCajas { get; set; }

    public virtual DbSet<InvCliente> InvClientes { get; set; }

    public virtual DbSet<InvConsecutivo> InvConsecutivos { get; set; }

    public virtual DbSet<InvCuentasxCobrar> InvCuentasxCobrars { get; set; }

    public virtual DbSet<InvDependiente> InvDependientes { get; set; }

    public virtual DbSet<InvDetalleCuenta> InvDetalleCuentas { get; set; }

    public virtual DbSet<InvDetalleMovimiento> InvDetalleMovimientos { get; set; }

    public virtual DbSet<InvFamilium> InvFamilia { get; set; }

    public virtual DbSet<InvMaestroCuenta> InvMaestroCuentas { get; set; }

    public virtual DbSet<InvMedida> InvMedidas { get; set; }

    public virtual DbSet<InvMovimiento> InvMovimientos { get; set; }

    public virtual DbSet<InvParametro> InvParametros { get; set; }

    public virtual DbSet<InvProveedore> InvProveedores { get; set; }

    public virtual DbSet<InvProvincia> InvProvincias { get; set; }

    public virtual DbSet<InvSubFamilium> InvSubFamilia { get; set; }

    public virtual DbSet<InvTipoAjuste> InvTipoAjustes { get; set; }

    public virtual DbSet<InvTipoPago> InvTipoPagos { get; set; }

    public virtual DbSet<InvUbicacionSalon> InvUbicacionSalons { get; set; }

    public virtual DbSet<InvUbicacione> InvUbicaciones { get; set; }

    public virtual DbSet<InvUsuario> InvUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvAperturaCaja>(entity =>
        {
            entity.ToTable("Inv_AperturaCajas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Monto)
                .HasColumnType("money")
                .HasColumnName("monto");
            entity.Property(e => e.Montocxc)
                .HasColumnType("money")
                .HasColumnName("montocxc");
        });

        modelBuilder.Entity<InvArticulo>(entity =>
        {
            entity.ToTable("Inv_Articulos");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.CantExistencia).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Cantareponer).HasColumnName("cantareponer");
            entity.Property(e => e.Costopromedio)
                .HasColumnType("money")
                .HasColumnName("costopromedio");
            entity.Property(e => e.FechaultimaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fechaultimaCompra");
            entity.Property(e => e.IdFamilia).HasColumnName("id_familia");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdSubfamilia).HasColumnName("id_subfamilia");
            entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("id_unidadMedida");
            entity.Property(e => e.IndCompuesto).HasColumnName("ind_compuesto");
            entity.Property(e => e.IndConsignacion).HasColumnName("ind_consignacion");
            entity.Property(e => e.IndFechavencimiento)
                .HasColumnType("datetime")
                .HasColumnName("ind_fechavencimiento");
            entity.Property(e => e.IndFraccionado).HasColumnName("ind_fraccionado");
            entity.Property(e => e.IndInventario).HasColumnName("ind_inventario");
            entity.Property(e => e.IndNumeroserie).HasColumnName("ind_numeroserie");
            entity.Property(e => e.IndVentapeso).HasColumnName("ind_ventapeso");
            entity.Property(e => e.IntDescuento)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("int_descuento");
            entity.Property(e => e.Montoimpuesto)
                .HasColumnType("money")
                .HasColumnName("montoimpuesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio1)
                .HasColumnType("money")
                .HasColumnName("precio1");
            entity.Property(e => e.Precio2)
                .HasColumnType("money")
                .HasColumnName("precio2");
            entity.Property(e => e.Precio3)
                .HasColumnType("money")
                .HasColumnName("precio3");
            entity.Property(e => e.PrecioCompra).HasColumnType("money");

            entity.HasOne(d => d.IdFamiliaNavigation).WithMany(p => p.InvArticulos)
                .HasForeignKey(d => d.IdFamilia)
                .HasConstraintName("FK_Inv_Articulos_Inv_Familia");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.InvArticulos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK_Inv_Articulos_Inv_Proveedores");

            entity.HasOne(d => d.IdSubfamiliaNavigation).WithMany(p => p.InvArticulos)
                .HasForeignKey(d => d.IdSubfamilia)
                .HasConstraintName("FK_Inv_Articulos_Inv_SubFamilia");
        });

        modelBuilder.Entity<InvArticulosCompuesto>(entity =>
        {
            entity.HasKey(e => e.IdArticulo);

            entity.ToTable("Inv_Articulos_Compuestos");

            entity.Property(e => e.IdArticulo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_articulo");
            entity.Property(e => e.Cantestablecida)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cantestablecida");
            entity.Property(e => e.Cantidadactual)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("cantidadactual");
            entity.Property(e => e.Idartidepen).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<InvCierreCaja>(entity =>
        {
            entity.ToTable("Inv_CierreCajas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.MontoCuentascobar)
                .HasColumnType("money")
                .HasColumnName("monto_cuentascobar");
            entity.Property(e => e.MontoEfectivo)
                .HasColumnType("money")
                .HasColumnName("monto_efectivo");
            entity.Property(e => e.MontoGastos)
                .HasColumnType("money")
                .HasColumnName("monto_gastos");
            entity.Property(e => e.MontoImpservicio)
                .HasColumnType("money")
                .HasColumnName("Monto_impservicio");
            entity.Property(e => e.MontoOtrosingresos)
                .HasColumnType("money")
                .HasColumnName("monto_otrosingresos");
            entity.Property(e => e.MontoTarjetas)
                .HasColumnType("money")
                .HasColumnName("monto_tarjetas");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("money")
                .HasColumnName("monto_total");
            entity.Property(e => e.MontoTrabajo)
                .HasColumnType("money")
                .HasColumnName("monto_trabajo");
            entity.Property(e => e.Montocxc)
                .HasColumnType("money")
                .HasColumnName("montocxc");
            entity.Property(e => e.Montodesc)
                .HasColumnType("money")
                .HasColumnName("montodesc");
            entity.Property(e => e.Montosinpe)
                .HasColumnType("money")
                .HasColumnName("montosinpe");
        });

        modelBuilder.Entity<InvCliente>(entity =>
        {
            entity.ToTable("Inv_Clientes");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Cuentabanco)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("cuentabanco");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telfax)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("telfax");
            entity.Property(e => e.Teloficina)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("teloficina");
        });

        modelBuilder.Entity<InvConsecutivo>(entity =>
        {
            entity.ToTable("Inv_Consecutivos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Consecutivo).HasColumnName("consecutivo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<InvCuentasxCobrar>(entity =>
        {
            entity.HasKey(e => e.Idcuenta);

            entity.ToTable("Inv_CuentasxCobrar");

            entity.Property(e => e.Idcuenta)
                .ValueGeneratedNever()
                .HasColumnName("idcuenta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Monto)
                .HasColumnType("money")
                .HasColumnName("monto");
        });

        modelBuilder.Entity<InvDependiente>(entity =>
        {
            entity.HasKey(e => e.IdDependiente);

            entity.ToTable("Inv_Dependiente");

            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<InvDetalleCuenta>(entity =>
        {
            entity.HasKey(e => new { e.IdCuenta, e.IdLinea }).HasName("PK_Inv_DetalleCuentas_1");

            entity.ToTable("Inv_DetalleCuentas");

            entity.Property(e => e.IdCuenta)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_cuenta");
            entity.Property(e => e.IdLinea)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_linea");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Cortesia).HasColumnName("cortesia");
            entity.Property(e => e.Costopromedio)
                .HasColumnType("money")
                .HasColumnName("costopromedio");
            entity.Property(e => e.Costoventa)
                .HasColumnType("money")
                .HasColumnName("costoventa");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.IdCodarticulo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_codarticulo");
            entity.Property(e => e.Impuestoventa).HasColumnName("impuestoventa");
            entity.Property(e => e.Opctipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("opctipo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Unidamedidad)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("unidamedidad");
        });

        modelBuilder.Entity<InvDetalleMovimiento>(entity =>
        {
            entity.HasKey(e => new { e.IdDocumento, e.IdArticulo });

            entity.ToTable("Inv_DetalleMovimientos");

            entity.Property(e => e.IdDocumento).HasColumnName("id_documento");
            entity.Property(e => e.IdArticulo).HasColumnName("id_Articulo");
            entity.Property(e => e.Cantidad)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("cantidad");
        });

        modelBuilder.Entity<InvFamilium>(entity =>
        {
            entity.HasKey(e => e.IdFamilia);

            entity.ToTable("Inv_Familia");

            entity.Property(e => e.IdFamilia).HasColumnName("id_familia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Informacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("informacion");
        });

        modelBuilder.Entity<InvMaestroCuenta>(entity =>
        {
            entity.HasKey(e => new { e.IdCuenta, e.IdFecha, e.IdClienteUbicacion });

            entity.ToTable("Inv_Maestro_Cuentas");

            entity.Property(e => e.IdCuenta)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_cuenta");
            entity.Property(e => e.IdFecha)
                .HasColumnType("datetime")
                .HasColumnName("id_fecha");
            entity.Property(e => e.IdClienteUbicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_cliente_Ubicacion");
            entity.Property(e => e.Descuento)
                .HasColumnType("money")
                .HasColumnName("descuento");
            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipoPago");
            entity.Property(e => e.ImpuestoServicio).HasColumnName("Impuesto_Servicio");
            entity.Property(e => e.Montoefectivo).HasColumnType("money");
            entity.Property(e => e.Montopago)
                .HasColumnType("money")
                .HasColumnName("montopago");
            entity.Property(e => e.Montotarjeta).HasColumnType("money");
        });

        modelBuilder.Entity<InvMedida>(entity =>
        {
            entity.HasKey(e => e.IdMedida);

            entity.ToTable("Inv_Medidas");

            entity.Property(e => e.IdMedida).HasColumnName("id_medida");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InvMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimientos);

            entity.ToTable("Inv_Movimientos");

            entity.Property(e => e.IdMovimientos)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_movimientos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechamov)
                .HasColumnType("datetime")
                .HasColumnName("fechamov");
            entity.Property(e => e.Idtipoajuste).HasColumnName("idtipoajuste");
            entity.Property(e => e.NumDocumento).HasColumnName("num_documento");
        });

        modelBuilder.Entity<InvParametro>(entity =>
        {
            entity.HasKey(e => e.IdParametro);

            entity.ToTable("Inv_parametros");

            entity.Property(e => e.IdParametro).HasColumnName("id_parametro");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Valorparam).HasColumnName("valorparam");
            entity.Property(e => e.Valorparam2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valorparam2");
            entity.Property(e => e.Valorparam3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("valorparam3");
        });

        modelBuilder.Entity<InvProveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.ToTable("Inv_Proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Apartadopostal)
                .HasMaxLength(20)
                .HasColumnName("apartadopostal");
            entity.Property(e => e.Cedula)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fechainiciorelacion)
                .HasColumnType("datetime")
                .HasColumnName("fechainiciorelacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Provincia).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Telcelular)
                .HasMaxLength(15)
                .HasColumnName("telcelular");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(15)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telfax)
                .HasMaxLength(15)
                .HasColumnName("telfax");
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website");

            entity.HasOne(d => d.ProvinciaNavigation).WithMany(p => p.InvProveedores)
                .HasForeignKey(d => d.Provincia)
                .HasConstraintName("FK_Inv_Proveedores_Inv_Provincias");
        });

        modelBuilder.Entity<InvProvincia>(entity =>
        {
            entity.ToTable("Inv_Provincias");

            entity.Property(e => e.Id).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Descripción).HasMaxLength(15);
        });

        modelBuilder.Entity<InvSubFamilium>(entity =>
        {
            entity.HasKey(e => e.IdSubfamilia);

            entity.ToTable("Inv_SubFamilia");

            entity.Property(e => e.IdSubfamilia).HasColumnName("id_subfamilia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdFamilia).HasColumnName("id_familia");
            entity.Property(e => e.Informacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("informacion");
        });

        modelBuilder.Entity<InvTipoAjuste>(entity =>
        {
            entity.ToTable("Inv_TipoAjustes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTipocuenta).HasColumnName("id_tipocuenta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<InvTipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("Inv_TipoPagos");

            entity.Property(e => e.IdTipo)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<InvUbicacionSalon>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK_Inv_ubicacion");

            entity.ToTable("Inv_ubicacion_Salon");

            entity.Property(e => e.IdMesa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_mesa");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<InvUbicacione>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion);

            entity.ToTable("Inv_ubicaciones");

            entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<InvUsuario>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK_usuarios");

            entity.ToTable("Inv_usuarios");

            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.IndEstado).HasColumnName("ind_Estado");
            entity.Property(e => e.Perfil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("perfil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

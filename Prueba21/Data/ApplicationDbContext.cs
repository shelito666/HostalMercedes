using Microsoft.EntityFrameworkCore;
using Prueba21.Models;

namespace Prueba21.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<FormaDePago> FormasDePago { get; set; }
        public DbSet<OrdenReserva> OrdenesReserva { get; set; }
        public DbSet<OrdenHospedaje> OrdenesHospedaje { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<OrdenConserjeria> OrdenesConserjeria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para OrdenConserjeria
            modelBuilder.Entity<OrdenConserjeria>()
                .HasOne(oc => oc.Habitacion)
                .WithMany(h => h.OrdenesConserjeria)
                .HasForeignKey(oc => oc.HabitacionId);

            modelBuilder.Entity<OrdenConserjeria>()
                .HasOne(oc => oc.Personal)
                .WithMany(p => p.OrdenesConserjeria)
                .HasForeignKey(oc => oc.PersonalId);

            // Configuración para OrdenReserva (1:N con Cliente)
            modelBuilder.Entity<OrdenReserva>()
                .HasOne(or => or.Cliente)
                .WithMany(c => c.OrdenReserva)
                .HasForeignKey(or => or.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para FormaDePago
            modelBuilder.Entity<FormaDePago>()
                .HasMany(fp => fp.OrdenesReserva)
                .WithOne(or => or.FormaDePago)
                .HasForeignKey(or => or.FormaDePagoId);

            modelBuilder.Entity<FormaDePago>()
                .HasMany(fp => fp.OrdenesHospedaje)
                .WithOne(oh => oh.FormaDePago)
                .HasForeignKey(oh => oh.FormaDePagoId);

            // Restricción CHECK para OrdenHospedaje
            modelBuilder.Entity<OrdenHospedaje>()
                .HasCheckConstraint(
                    name: "CHK_OrdenHospedaje_Tipo",
                    sql: "(OrdenReservaId IS NOT NULL) OR (ClienteId IS NOT NULL AND HabitacionId IS NOT NULL)"
                );

            modelBuilder.Entity<Personal>().HasData(
                new Personal
                    {
                        PersonalId = 1,
                        Nombre = "Administrador",
                        Email = "admin@gmail.com",
                        Contrasenia = "admin",
                        Rol = "Administrador"
                    }
                );

            modelBuilder.Entity<FormaDePago>().HasData(
                    new FormaDePago
                    {
                        FormaDePagoId = 1,
                        Nombre = "Efectivo"
                    },
                    new FormaDePago
                    {
                        FormaDePagoId = 2,
                        Nombre = "Tarjeta de Crédito"
                    },
                    new FormaDePago
                    {
                        FormaDePagoId = 3,
                        Nombre = "Tarjeta de Débito"
                    },
                    new FormaDePago
                    {
                        FormaDePagoId = 4,
                        Nombre = "Transferencia Bancaria"
                    }
                );

            modelBuilder.Entity<Habitacion>().HasData(
                    new Habitacion
                    {
                        HabitacionId = 1,
                        Numero = "101",
                        Tipo = "Sencilla",
                        Precio = 100,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 2,
                        Numero = "102",
                        Tipo = "Doble",
                        Precio = 150,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 3,
                        Numero = "103",
                        Tipo = "Triple",
                        Precio = 200,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 4,
                        Numero = "104",
                        Tipo = "Suite",
                        Precio = 300,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 5,
                        Numero = "105",
                        Tipo = "Suite Presidencial",
                        Precio = 500,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 6,
                        Numero = "106",
                        Tipo = "Sencilla",
                        Precio = 100,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 7,
                        Numero = "107",
                        Tipo = "Doble",
                        Precio = 150,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 8,
                        Numero = "108",
                        Tipo = "Triple",
                        Precio = 200,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 9,
                        Numero = "109",
                        Tipo = "Suite",
                        Precio = 300,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    },
                    new Habitacion
                    {
                        HabitacionId = 10,
                        Numero = "110",
                        Tipo = "Suite Presidencial",
                        Precio = 500,
                        Estado = Habitacion.EstadoHabitacion.Disponible
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

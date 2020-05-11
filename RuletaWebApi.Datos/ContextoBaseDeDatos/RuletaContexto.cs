using Microsoft.EntityFrameworkCore;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Datos.ContextoBaseDeDatos
{
    public class RuletaContexto : DbContext
    {

        public string CadenaConexion { get; set; }
        public DbSet<Ruleta> Ruletas { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public RuletaContexto(DbContextOptions<RuletaContexto> options) : base(options)
        {

        }

        public RuletaContexto()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CadenaConexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ruleta>().ToTable("Ruleta");
            modelBuilder.Entity<Ruleta>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<Ruleta>().Property(x => x.Estado).HasColumnName("Estado");

            modelBuilder.Entity<Apuesta>().ToTable("Apuesta");

            modelBuilder.Entity<Apuesta>()
                                        .HasOne(bc => bc.Cliente)
                                        .WithMany(b => b.Apuestas)
                                        .HasForeignKey(bc => bc.ClienteId);

            modelBuilder.Entity<Apuesta>()
                                        .HasOne(bc => bc.Ruleta)
                                        .WithMany(c => c.Apuestas)
                                        .HasForeignKey(bc => bc.RuletaId);

            modelBuilder.Entity<Apuesta>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<Apuesta>().Property(x => x.Color).HasColumnName("Color");
            modelBuilder.Entity<Apuesta>().Property(x => x.Fecha).HasColumnName("Fecha");
            modelBuilder.Entity<Apuesta>().Property(x => x.NumeroApuesta).HasColumnName("Numero");
            modelBuilder.Entity<Apuesta>().Property(x => x.ValorApuesta).HasColumnName("Valor");
            modelBuilder.Entity<Apuesta>().Property(x => x.ClienteId).HasColumnName("ClienteId");
            modelBuilder.Entity<Apuesta>().Property(x => x.RuletaId).HasColumnName("RuletaId");


            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            modelBuilder.Entity<Cliente>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<Cliente>().Property(x => x.Nombres).HasColumnName("Nombres");
            modelBuilder.Entity<Cliente>().Property(x => x.Apellidos).HasColumnName("Apellidos");
            modelBuilder.Entity<Cliente>().Property(x => x.Saldo).HasColumnName("Saldo");


        }
    }
}
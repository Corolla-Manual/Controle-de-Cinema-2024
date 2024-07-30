using ControleDeCinema.Dominio.ModuloFilme;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString("SqlServer")!;

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filme>(filmeBuilder =>
        {
            filmeBuilder.ToTable("TbFilme");

            filmeBuilder.Property(f => f.Id)
                .IsRequired()
                .ValueGenerateOnAdd();

            filmeBuilder.Property(f => f.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            filmeBuilder.Property(f => f.Duracao)
                .IsRequired()
                .HasColumnType("datetime2");

            filmeBuilder.Property(f => f.Genero)
                .IsRequired()
                .HasColumnType("varchar(100)");

        });

        base.OnModelCreating(modelBuilder);
    }
}
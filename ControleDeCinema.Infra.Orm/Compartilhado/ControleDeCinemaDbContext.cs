using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Funcionario> Funcionarios{ get; set; }

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

            filmeBuilder.Property(f => f.Estreia)
                .IsRequired()
                .HasColumnType("bit");
        });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sala>(salaBuilder =>
        {
            salaBuilder.ToTable("TbSala");

            salaBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGenerateOnAdd();

            salaBuilder.Property(s => s.Numero)
                .IsRequired()
                .HasColumnType("int");

            salaBuilder.Property(s => s.Capacidade)
                .IsRequired()
                .HasColumnType("int");
        });

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>(funcionarioBuilder =>
        {
            funcionarioBuilder.ToTable("TbFuncionario");

            funcionarioBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGenerateOnAdd();

            funcionarioBuilder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            funcionarioBuilder.Property(s => s.Login)
                .IsRequired()
                .HasColumnType("varchar(200)");

            funcionarioBuilder.Property(s => s.Senha)
                .IsRequired()
                .HasColumnType("varchar(200)");
        });

        base.OnModelCreating(modelBuilder);
    }
}
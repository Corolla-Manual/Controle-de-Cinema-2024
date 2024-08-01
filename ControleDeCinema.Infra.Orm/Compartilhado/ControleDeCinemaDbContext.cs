using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Dominio.ModuloSessao.ModuloIngresso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinemaDbContext : DbContext
{
	public DbSet<Filme> Filmes { get; set; }
	public DbSet<Sala> Salas { get; set; }
	public DbSet<Sessao> Sessoes { get; set; }
	public DbSet<Ingresso> Ingressos { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }

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
		//Filme
		modelBuilder.Entity<Filme>(filmeBuilder =>
		{
			filmeBuilder.ToTable("TbFilme");

			filmeBuilder.Property(f => f.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			filmeBuilder.Property(f => f.Titulo)
				.IsRequired()
				.HasColumnType("varchar(200)");

			filmeBuilder.Property(f => f.Duracao)
				.IsRequired()
				.HasColumnType("int");

			filmeBuilder.Property(f => f.Genero)
				.IsRequired()
				.HasColumnType("varchar(100)");

			filmeBuilder.Property(f => f.Estreia)
				.IsRequired()
				.HasColumnType("bit");
		});

		//Sala
		modelBuilder.Entity<Sala>(salaBuilder =>
		{
			salaBuilder.ToTable("TbSala");

			salaBuilder.Property(s => s.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			salaBuilder.Property(s => s.Numero)
				.IsRequired()
				.HasColumnType("int");

			salaBuilder.Property(s => s.Capacidade)
				.IsRequired()
				.HasColumnType("int");
		});

		//Sessao
		modelBuilder.Entity<Sessao>(sessaoBuilder =>
		{
			sessaoBuilder.ToTable("TbSessao");

			sessaoBuilder.Property(s => s.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			sessaoBuilder.Property(s => s.Horario)
				.IsRequired()
				.HasColumnType("datetime2");

			sessaoBuilder.Property(s => s.IngressosDisponiveis)
				.IsRequired()
				.HasColumnType("int");

			sessaoBuilder.HasOne(s => s.Filme)
				.WithMany(f => f.Sessoes)
				.HasForeignKey("Filme_Id")
				.HasConstraintName("Fk_TbSessao_TbFilme")
				.OnDelete(DeleteBehavior.Restrict);

			sessaoBuilder.HasOne(s => s.Sala)
				.WithMany(s => s.Sessoes)
				.HasForeignKey("Sala_Id")
				.HasConstraintName("FK_TbSessao_TbSala")
				.OnDelete(DeleteBehavior.Restrict);

			sessaoBuilder.HasMany(s => s.Ingressos)
				.WithOne()
				.HasForeignKey("Sessao_Id")
				.HasConstraintName("FK_TbSessao_TbIngresso")
				.OnDelete(DeleteBehavior.Restrict);
		});

		//Ingresso

		modelBuilder.Entity<Ingresso>(ingressoBuilder =>
		{
			ingressoBuilder.ToTable("TbIngresso");

			ingressoBuilder.Property(i => i.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			ingressoBuilder.Property(i => i.NumeroPoltrona)
				.IsRequired()
				.HasColumnType("int");

			ingressoBuilder.Property(i => i.Tipo)
				.IsRequired()
				.HasColumnType("int");

			ingressoBuilder.Property(i => i.Valor)
				.IsRequired()
				.HasColumnType("real");

			ingressoBuilder.HasOne(i => i.Funcionario)
				.WithMany()
				.HasConstraintName("Funcionario_Id")
				.HasConstraintName("FK_TbIngresso_TbFuncionario")
				.OnDelete(DeleteBehavior.Restrict);

		});

		//Funcionario
		modelBuilder.Entity<Funcionario>(funcionarioBuilder =>
		{
			funcionarioBuilder.ToTable("TbFuncionario");

			funcionarioBuilder.Property(s => s.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

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
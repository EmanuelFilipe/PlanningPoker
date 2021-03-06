﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningPoker.Data.Context;

namespace PlanningPoker.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210221201256_Votos")]
    partial class Votos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlanningPoker.Models.Carta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ValorCarta")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cartas");
                });

            modelBuilder.Entity("PlanningPoker.Models.HistoriaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("HistoriaUsuarios");
                });

            modelBuilder.Entity("PlanningPoker.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PlanningPoker.Models.Voto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartaId");

                    b.Property<int>("HistoriaUsuarioId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CartaId");

                    b.HasIndex("HistoriaUsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Votos");
                });

            modelBuilder.Entity("PlanningPoker.Models.Voto", b =>
                {
                    b.HasOne("PlanningPoker.Models.Carta", "Carta")
                        .WithMany()
                        .HasForeignKey("CartaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PlanningPoker.Models.HistoriaUsuario", "HistoriaUsuario")
                        .WithMany()
                        .HasForeignKey("HistoriaUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PlanningPoker.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

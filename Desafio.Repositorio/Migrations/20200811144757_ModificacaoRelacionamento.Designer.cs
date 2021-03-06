﻿// <auto-generated />
using Desafio.Repositorio.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.Repositorio.Migrations
{
    [DbContext(typeof(DesafioContext))]
    [Migration("20200811144757_ModificacaoRelacionamento")]
    partial class ModificacaoRelacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Desafio.Dominio.Entidades.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataNascimento")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("EquipeId");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Desafio.Dominio.Entidades.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeEquipe")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NomeGestor")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Desafio.Dominio.Entidades.Colaborador", b =>
                {
                    b.HasOne("Desafio.Dominio.Entidades.Equipe", "Equipe")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

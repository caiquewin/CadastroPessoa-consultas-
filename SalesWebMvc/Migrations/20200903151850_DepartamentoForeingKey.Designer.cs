﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMvc.Data;

namespace SalesWebMvc.Migrations
{
    [DbContext(typeof(SalesWebMvcContext))]
    [Migration("20200903151850_DepartamentoForeingKey")]
    partial class DepartamentoForeingKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SalesWebMvc.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNasci");

                    b.Property<string>("Nome");

                    b.Property<int>("NumeCel");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Comentario");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("EspecialistaId");

                    b.Property<int>("StatusPagamento");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EspecialistaId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<double>("Salario");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Especialista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cro");

                    b.Property<string>("CroEstado");

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Especialista");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Consulta", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Cliente", "Cliente")
                        .WithMany("Consultas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("SalesWebMvc.Models.Especialista", "Especialista")
                        .WithMany("Consultas")
                        .HasForeignKey("EspecialistaId");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Especialista", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Departamento", "Departamento")
                        .WithMany("Especialistas")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

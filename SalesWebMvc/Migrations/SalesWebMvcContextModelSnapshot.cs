﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMvc.Models;

namespace SalesWebMvc.Migrations
{
    [DbContext(typeof(SalesWebMvcContext))]
    partial class SalesWebMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SalesWebMvc.Models.SallesRecord", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("Sellerid");

                    b.Property<int>("Status");

                    b.HasKey("id");

                    b.HasIndex("Sellerid");

                    b.ToTable("SallesRecord");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Seller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("Departamentid");

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("Departamentid");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("SalesWebMvc.Models.ViewModels.Departament", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<string>("Responsavel");

                    b.Property<string>("Telefone");

                    b.Property<string>("nscricaoEstadual");

                    b.HasKey("id");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("SalesWebMvc.Models.SallesRecord", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Seller", "Seller")
                        .WithMany("Sales")
                        .HasForeignKey("Sellerid");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Seller", b =>
                {
                    b.HasOne("SalesWebMvc.Models.ViewModels.Departament", "Departament")
                        .WithMany("Sellers")
                        .HasForeignKey("Departamentid");
                });
#pragma warning restore 612, 618
        }
    }
}

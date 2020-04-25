﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotTaxTim.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NotTaxTim.Database.Migrations
{
    [DbContext(typeof(NotTaxTimDbContext))]
    [Migration("20200425193123_SeedPostalCodeData")]
    partial class SeedPostalCodeData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.CalculationResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AnnualIncome")
                        .HasColumnType("numeric");

                    b.Property<long?>("CalculationTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("PostalCodeId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaxCalculationType")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalTax")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CalculationTypeId");

                    b.HasIndex("PostalCodeId");

                    b.ToTable("CalculationResults");
                });

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.CalculationRuleType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("PostalCodeId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaxCalculationTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PostalCodeId");

                    b.HasIndex("TaxCalculationTypeId");

                    b.ToTable("CalculationRuleTypes");
                });

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.PostalCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostalCodes");
                });

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.TaxCalculationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CalculationType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TaxCalculationTypes");
                });

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.CalculationResult", b =>
                {
                    b.HasOne("NotTaxTim.Database.EntityModels.TaxCalculationType", "CalculationType")
                        .WithMany()
                        .HasForeignKey("CalculationTypeId");

                    b.HasOne("NotTaxTim.Database.EntityModels.PostalCode", "PostalCode")
                        .WithMany()
                        .HasForeignKey("PostalCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotTaxTim.Database.EntityModels.CalculationRuleType", b =>
                {
                    b.HasOne("NotTaxTim.Database.EntityModels.PostalCode", "PostalCode")
                        .WithMany()
                        .HasForeignKey("PostalCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotTaxTim.Database.EntityModels.TaxCalculationType", "TaxCalculationType")
                        .WithMany()
                        .HasForeignKey("TaxCalculationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

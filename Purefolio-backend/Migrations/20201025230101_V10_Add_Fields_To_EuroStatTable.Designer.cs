﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Purefolio.DatabaseContext;

namespace Purefolio_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201025230101_V10_Add_Fields_To_EuroStatTable")]
    partial class V10_Add_Fields_To_EuroStatTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Purefolio_backend.Models.EuroStatTable", b =>
                {
                    b.Property<int>("tableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("table_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("attributeName")
                        .HasColumnName("attribute_name")
                        .HasColumnType("text");

                    b.Property<string>("dataType")
                        .HasColumnName("data_type")
                        .HasColumnType("text");

                    b.Property<string>("datasetName")
                        .HasColumnName("dataset_name")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("esgFactor")
                        .HasColumnName("esg_factor")
                        .HasColumnType("text");

                    b.Property<string>("filters")
                        .HasColumnName("filters")
                        .HasColumnType("text");

                    b.Property<string>("tableCode")
                        .HasColumnName("table_code")
                        .HasColumnType("text");

                    b.Property<string>("unit")
                        .HasColumnName("unit")
                        .HasColumnType("text");

                    b.HasKey("tableId")
                        .HasName("pk_euro_stat_table");

                    b.ToTable("EuroStatTable");
                });

            modelBuilder.Entity("Purefolio_backend.Models.Nace", b =>
                {
                    b.Property<int>("naceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nace_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("naceCode")
                        .IsRequired()
                        .HasColumnName("nace_code")
                        .HasColumnType("text");

                    b.Property<string>("naceName")
                        .HasColumnName("nace_name")
                        .HasColumnType("text");

                    b.HasKey("naceId")
                        .HasName("pk_nace");

                    b.ToTable("Nace");
                });

            modelBuilder.Entity("Purefolio_backend.Models.NaceRegionData", b =>
                {
                    b.Property<int>("naceRegionDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nace_region_data_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double?>("emissionPerYear")
                        .HasColumnName("emission_per_year")
                        .HasColumnType("double precision");

                    b.Property<double?>("employeesPrimaryEducation")
                        .HasColumnName("employees_primary_education")
                        .HasColumnType("double precision");

                    b.Property<double?>("employeesSecondaryEducation")
                        .HasColumnName("employees_secondary_education")
                        .HasColumnType("double precision");

                    b.Property<double?>("employeesTertiaryEducation")
                        .HasColumnName("employees_tertiary_education")
                        .HasColumnType("double precision");

                    b.Property<double?>("environmentTaxes")
                        .HasColumnName("environment_taxes")
                        .HasColumnType("double precision");

                    b.Property<double?>("fatalAccidentsAtWork")
                        .HasColumnName("fatal_accidents_at_work")
                        .HasColumnType("double precision");

                    b.Property<double?>("genderPayGap")
                        .HasColumnName("gender_pay_gap")
                        .HasColumnType("double precision");

                    b.Property<int>("naceId")
                        .HasColumnName("nace_id")
                        .HasColumnType("integer");

                    b.Property<int>("regionId")
                        .HasColumnName("region_id")
                        .HasColumnType("integer");

                    b.Property<double?>("temporaryemployment")
                        .HasColumnName("temporaryemployment")
                        .HasColumnType("double precision");

                    b.Property<double?>("workAccidentsIncidentRate")
                        .HasColumnName("work_accidents_incident_rate")
                        .HasColumnType("double precision");

                    b.Property<int>("year")
                        .HasColumnName("year")
                        .HasColumnType("integer");

                    b.HasKey("naceRegionDataId")
                        .HasName("pk_nace_region_data");

                    b.HasIndex("naceId")
                        .HasName("ix_nace_region_data_nace_id");

                    b.HasIndex("regionId")
                        .HasName("ix_nace_region_data_region_id");

                    b.ToTable("NaceRegionData");
                });

            modelBuilder.Entity("Purefolio_backend.Models.Region", b =>
                {
                    b.Property<int>("regionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("region_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("area")
                        .HasColumnName("area")
                        .HasColumnType("integer");

                    b.Property<string>("regionCode")
                        .IsRequired()
                        .HasColumnName("region_code")
                        .HasColumnType("text");

                    b.Property<string>("regionName")
                        .HasColumnName("region_name")
                        .HasColumnType("text");

                    b.HasKey("regionId")
                        .HasName("pk_region");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Purefolio_backend.Models.RegionData", b =>
                {
                    b.Property<int>("regionDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("region_data_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("corruptionRate")
                        .HasColumnName("corruption_rate")
                        .HasColumnType("integer");

                    b.Property<int?>("gdp")
                        .HasColumnName("gdp")
                        .HasColumnType("integer");

                    b.Property<int?>("population")
                        .HasColumnName("population")
                        .HasColumnType("integer");

                    b.Property<int>("regionId")
                        .HasColumnName("region_id")
                        .HasColumnType("integer");

                    b.Property<int>("year")
                        .HasColumnName("year")
                        .HasColumnType("integer");

                    b.HasKey("regionDataId")
                        .HasName("pk_region_data");

                    b.HasIndex("regionId")
                        .HasName("ix_region_data_region_id");

                    b.ToTable("RegionData");
                });

            modelBuilder.Entity("Purefolio_backend.Models.NaceRegionData", b =>
                {
                    b.HasOne("Purefolio_backend.Models.Nace", "nace")
                        .WithMany()
                        .HasForeignKey("naceId")
                        .HasConstraintName("fk_nace_region_data_nace_nace_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Purefolio_backend.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionId")
                        .HasConstraintName("fk_nace_region_data_region_region_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Purefolio_backend.Models.RegionData", b =>
                {
                    b.HasOne("Purefolio_backend.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionId")
                        .HasConstraintName("fk_region_data_region_region_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

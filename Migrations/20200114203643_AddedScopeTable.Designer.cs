﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WatchdogApi.Models;

namespace WatchdogApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200114203643_AddedScopeTable")]
    partial class AddedScopeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WatchdogApi.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BuildingName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBuildingAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("WatchdogApi.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateFacilityAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("WatchdogApi.Models.Scope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Scopes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Site"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fixed System: Roof"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fixed System: Building Interior"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fixed System: Building Exterior"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Operating System: HVAC"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Operating System: Electrical"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Operating System: Plumbing"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Operating System: Fire & Life Safety"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Operating System: Kitchen"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Operating System: Vertical Transport"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Other"
                        });
                });

            modelBuilder.Entity("WatchdogApi.Models.Building", b =>
                {
                    b.HasOne("WatchdogApi.Models.Facility", "Facilities")
                        .WithMany("Buildings")
                        .HasForeignKey("FacilityId");
                });
#pragma warning restore 612, 618
        }
    }
}

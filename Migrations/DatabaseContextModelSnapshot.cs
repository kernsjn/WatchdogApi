﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WatchdogApi.Models;

namespace WatchdogApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WatchdogApi.Models.AssignPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AssignRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AssignPersons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignRole = "Owner"
                        },
                        new
                        {
                            Id = 2,
                            AssignRole = "Architect"
                        },
                        new
                        {
                            Id = 3,
                            AssignRole = "General Contractor"
                        },
                        new
                        {
                            Id = 4,
                            AssignRole = "Subcontractor"
                        });
                });

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

            modelBuilder.Entity("WatchdogApi.Models.PunchListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AssignId")
                        .HasColumnType("integer");

                    b.Property<int?>("AssignPersonId")
                        .HasColumnType("integer");

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<string>("Issue")
                        .HasColumnType("text");

                    b.Property<string>("IssueLocation")
                        .HasColumnType("text");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<int?>("RequestorId")
                        .HasColumnType("integer");

                    b.Property<int>("ScopeId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssignPersonId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("RequestorId");

                    b.HasIndex("ScopeId");

                    b.ToTable("PunchListItems");
                });

            modelBuilder.Entity("WatchdogApi.Models.Requestor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RequestRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Requestors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RequestRole = "Owner"
                        },
                        new
                        {
                            Id = 2,
                            RequestRole = "Architect"
                        },
                        new
                        {
                            Id = 3,
                            RequestRole = "General Contractor"
                        },
                        new
                        {
                            Id = 4,
                            RequestRole = "Subcontractor"
                        });
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

            modelBuilder.Entity("WatchdogApi.Models.PunchListItem", b =>
                {
                    b.HasOne("WatchdogApi.Models.AssignPerson", "AssignPerson")
                        .WithMany()
                        .HasForeignKey("AssignPersonId");

                    b.HasOne("WatchdogApi.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchdogApi.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchdogApi.Models.Requestor", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.HasOne("WatchdogApi.Models.Scope", "Scope")
                        .WithMany()
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

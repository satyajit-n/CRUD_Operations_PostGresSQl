﻿// <auto-generated />
using System;
using CRUD_Operations_PostGresSQl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRUD_Operations_PostGresSQl.Migrations
{
    [DbContext(typeof(CrudDbContext))]
    [Migration("20230809070133_minorchanges4")]
    partial class minorchanges4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.ActionTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActionTable");

                    b.HasData(
                        new
                        {
                            Id = 400,
                            ActionName = "View"
                        },
                        new
                        {
                            Id = 401,
                            ActionName = "Add"
                        },
                        new
                        {
                            Id = 402,
                            ActionName = "Update"
                        },
                        new
                        {
                            Id = 403,
                            ActionName = "Delete"
                        },
                        new
                        {
                            Id = 404,
                            ActionName = "Review"
                        });
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.ApplicantsCreateEntry", b =>
                {
                    b.Property<Guid>("ApplicantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApllicantBranch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantApplicationType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantCustomerName")
                        .HasColumnType("text");

                    b.Property<DateOnly>("ApplicantDate")
                        .HasColumnType("date");

                    b.Property<string>("ApplicantLevel")
                        .HasColumnType("text");

                    b.Property<bool>("ApplicantMarkedForReview")
                        .HasColumnType("boolean");

                    b.Property<string>("ApplicantNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantPanCard")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ApplicantID");

                    b.ToTable("ApplicantsCreateEntries");
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.EntitlementTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuRefId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleRefId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("MenuRefId");

                    b.HasIndex("RoleRefId");

                    b.ToTable("EntitlementTables");

                    b.HasData(
                        new
                        {
                            Id = 301,
                            ActionId = 400,
                            MenuRefId = 100,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 302,
                            ActionId = 401,
                            MenuRefId = 100,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 303,
                            ActionId = 402,
                            MenuRefId = 100,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 304,
                            ActionId = 403,
                            MenuRefId = 100,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 305,
                            ActionId = 404,
                            MenuRefId = 100,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 306,
                            ActionId = 400,
                            MenuRefId = 101,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 307,
                            ActionId = 401,
                            MenuRefId = 101,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 308,
                            ActionId = 402,
                            MenuRefId = 101,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 309,
                            ActionId = 403,
                            MenuRefId = 101,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 310,
                            ActionId = 404,
                            MenuRefId = 101,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 311,
                            ActionId = 400,
                            MenuRefId = 102,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 312,
                            ActionId = 401,
                            MenuRefId = 102,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 313,
                            ActionId = 404,
                            MenuRefId = 102,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 314,
                            ActionId = 400,
                            MenuRefId = 103,
                            RoleRefId = 200
                        },
                        new
                        {
                            Id = 315,
                            ActionId = 400,
                            MenuRefId = 103,
                            RoleRefId = 201
                        });
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.LeadList", b =>
                {
                    b.Property<Guid>("LeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LeadAssignedTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadContactNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadCreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LeadCreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LeadEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadFirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadLoanType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LeadMarkedForReview")
                        .HasColumnType("boolean");

                    b.Property<string>("LeadMiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadUpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LeadUpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LeadId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            MenuName = "Leads"
                        },
                        new
                        {
                            Id = 101,
                            MenuName = "Applicants"
                        },
                        new
                        {
                            Id = 102,
                            MenuName = "Legal Verification"
                        },
                        new
                        {
                            Id = 103,
                            MenuName = "Setting"
                        });
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 200,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 201,
                            Role = "Manager"
                        });
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CRUD_Operations_PostGresSQl.Models.Domain.EntitlementTable", b =>
                {
                    b.HasOne("CRUD_Operations_PostGresSQl.Models.Domain.ActionTable", "ActionTable")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUD_Operations_PostGresSQl.Models.Domain.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUD_Operations_PostGresSQl.Models.Domain.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionTable");

                    b.Navigation("Menu");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

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
    [Migration("20230804103947_ForeignKeyToMenu")]
    partial class ForeignKeyToMenu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

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

                    b.Property<int>("MenuRefId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleRefId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MenuRefId");

                    b.HasIndex("RoleRefId");

                    b.ToTable("EntitlementTables");
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("LeadCreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("LeadEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadLoanType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LeadMarkedForReview")
                        .HasColumnType("boolean");

                    b.Property<string>("LeadProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeadStatus")
                        .IsRequired()
                        .HasColumnType("text");

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
                            Id = 200,
                            MenuName = "Applicants"
                        },
                        new
                        {
                            Id = 300,
                            MenuName = "Legal Verification"
                        },
                        new
                        {
                            Id = 400,
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
                            Id = 1,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
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

                    b.Navigation("Menu");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

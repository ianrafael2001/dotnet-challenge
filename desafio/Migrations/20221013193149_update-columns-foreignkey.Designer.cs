﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using desafio.Models;
using desafio.Context;

#nullable disable

namespace desafio.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20221013193149_update-columns-foreignkey")]
    partial class updatecolumnsforeignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("desafio.Entity.EmployeeEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("desafio.Entity.MemberEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("employeeId")
                        .HasColumnType("integer");

                    b.Property<int>("projectId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.HasIndex("projectId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("desafio.Entity.ProjectEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("managerId")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("managerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("desafio.Entity.MemberEntity", b =>
                {
                    b.HasOne("desafio.Entity.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("desafio.Entity.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("desafio.Entity.ProjectEntity", b =>
                {
                    b.HasOne("desafio.Entity.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("managerId");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}

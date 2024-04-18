﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceCenter.Data;

#nullable disable

namespace ResourceCenter.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240416091553_sqlite.local_migration_925")]
    partial class sqlitelocal_migration_925
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("AccountResident", b =>
                {
                    b.Property<int>("AccountsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResidentsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountsId", "ResidentsId");

                    b.HasIndex("ResidentsId");

                    b.ToTable("AccountResident");
                });

            modelBuilder.Entity("ResourceCenter.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Area")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Closed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Opened")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ResourceCenter.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResidentType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("AccountResident", b =>
                {
                    b.HasOne("ResourceCenter.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceCenter.Resident", null)
                        .WithMany()
                        .HasForeignKey("ResidentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

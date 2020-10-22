﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeriParkDemo.Context;

namespace VeriParkDemo.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20201021110732_NewVersionOfDb")]
    partial class NewVersionOfDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VeriParkDemo.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstWeekendDay")
                        .HasColumnType("int");

                    b.Property<int>("SecondWeekendDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "Türkiye",
                            CurrencyCode = "TRY",
                            FirstWeekendDay = 6,
                            SecondWeekendDay = 0
                        },
                        new
                        {
                            Id = 2,
                            CountryName = "USA",
                            CurrencyCode = "USD",
                            FirstWeekendDay = 0,
                            SecondWeekendDay = 1
                        });
                });

            modelBuilder.Entity("VeriParkDemo.Models.CountryBasedHoliday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HolidayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HolidayType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryBasedHoliday");
                });

            modelBuilder.Entity("VeriParkDemo.Models.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RetunDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Penalty");
                });

            modelBuilder.Entity("VeriParkDemo.Models.CountryBasedHoliday", b =>
                {
                    b.HasOne("VeriParkDemo.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
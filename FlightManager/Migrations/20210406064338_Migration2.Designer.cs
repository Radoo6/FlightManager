﻿// <auto-generated />
using System;
using FlightManagerData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightManager.Migrations
{
    [DbContext(typeof(FlightContext))]
    [Migration("20210406064338_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightManagerData.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Egn")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FlightManagerData.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessClassCapacity")
                        .HasColumnType("int");

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("PassengersCapacity")
                        .HasColumnType("int");

                    b.Property<string>("PilotName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PlaneType")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PlaneUniqueNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("FlightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightManagerData.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Egn")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsBusiness")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PassengerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("FlightManagerData.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ReservationId");

                    b.HasIndex("FlightId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("FlightManagerData.Models.Passenger", b =>
                {
                    b.HasOne("FlightManagerData.Models.Reservation", null)
                        .WithMany("Passengers")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("FlightManagerData.Models.Reservation", b =>
                {
                    b.HasOne("FlightManagerData.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightManagerData.Models.Reservation", b =>
                {
                    b.Navigation("Passengers");
                });
#pragma warning restore 612, 618
        }
    }
}

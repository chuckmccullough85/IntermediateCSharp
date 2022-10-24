﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketModel;

#nullable disable

namespace TicketHub_EF.Migrations
{
    [DbContext(typeof(TicketModelContext))]
    [Migration("20220520131239_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketModel.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TicketModel.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<short>("Row")
                        .HasColumnType("smallint");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TicketModel.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TicketHolderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SeatId");

                    b.HasIndex("TicketHolderId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketModel.TicketHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketHolders");
                });

            modelBuilder.Entity("TicketModel.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("TicketModel.Event", b =>
                {
                    b.HasOne("TicketModel.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("TicketModel.Seat", b =>
                {
                    b.HasOne("TicketModel.Venue", "Venue")
                        .WithMany("Seats")
                        .HasForeignKey("VenueId");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("TicketModel.Ticket", b =>
                {
                    b.HasOne("TicketModel.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId");

                    b.HasOne("TicketModel.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId");

                    b.HasOne("TicketModel.TicketHolder", "TicketHolder")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketHolderId");

                    b.Navigation("Event");

                    b.Navigation("Seat");

                    b.Navigation("TicketHolder");
                });

            modelBuilder.Entity("TicketModel.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketModel.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketModel.TicketHolder", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketModel.Venue", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
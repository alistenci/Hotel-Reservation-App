﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eHotelApp.Infrastructure.Context;

#nullable disable

namespace eHotelApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241010195801_mg1")]
    partial class mg1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("VerificationExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.FloorRooms", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("RoomName")
                        .HasColumnType("text");

                    b.Property<string>("RoomType")
                        .HasColumnType("text");

                    b.Property<int>("floorNumber")
                        .HasColumnType("integer");

                    b.Property<Guid?>("hotelRoomsId")
                        .HasColumnType("uuid");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("roomCount")
                        .HasColumnType("integer");

                    b.Property<int>("roomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("hotelRoomsId");

                    b.ToTable("FloorRoomss");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.Guests", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("ReservationsId")
                        .HasColumnType("uuid");

                    b.Property<string>("eMail")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityNumber")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("ReservationsId");

                    b.HasIndex("eMail")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.HotelRooms", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("RoomName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RoomType")
                        .HasColumnType("text");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("floorNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("maxGuests")
                        .HasColumnType("integer");

                    b.Property<int>("minGuests")
                        .HasColumnType("integer");

                    b.Property<int>("roomCount")
                        .HasColumnType("integer");

                    b.Property<int>("roomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.Reservations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.RoomFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FeatureName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RoomFeatures");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.RoomInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ReservationsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReservationsId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomInstances");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypess");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.FloorRooms", b =>
                {
                    b.HasOne("eHotelApp.Domain.Entities.HotelRooms", "hotelRooms")
                        .WithMany()
                        .HasForeignKey("hotelRoomsId");

                    b.Navigation("hotelRooms");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.Guests", b =>
                {
                    b.HasOne("eHotelApp.Domain.Entities.Reservations", null)
                        .WithMany("Guests")
                        .HasForeignKey("ReservationsId");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.RoomInstance", b =>
                {
                    b.HasOne("eHotelApp.Domain.Entities.Reservations", null)
                        .WithMany("ReservedRooms")
                        .HasForeignKey("ReservationsId");

                    b.HasOne("eHotelApp.Domain.Entities.HotelRooms", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("eHotelApp.Domain.Entities.Reservations", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("ReservedRooms");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripLogServer.Infrastructure.Context;

#nullable disable

namespace TripLogServer.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241102114129_mg-7")]
    partial class mg7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TagTripEntity", b =>
                {
                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TripsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TagsId", "TripsId");

                    b.HasIndex("TripsId");

                    b.ToTable("TagTripEntity");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAuthor")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("appUsers");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.Command", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TripEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("TripEntityId");

                    b.ToTable("commands");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.TripContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.TripEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TagTripEntity", b =>
                {
                    b.HasOne("TripLogServer.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripLogServer.Domain.Entities.TripEntity", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.Command", b =>
                {
                    b.HasOne("TripLogServer.Domain.Entities.AppUser", "AppUser")
                        .WithMany("Commands")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripLogServer.Domain.Entities.TripEntity", "TripEntity")
                        .WithMany("Commands")
                        .HasForeignKey("TripEntityId");

                    b.Navigation("AppUser");

                    b.Navigation("TripEntity");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.TripContent", b =>
                {
                    b.HasOne("TripLogServer.Domain.Entities.TripEntity", "Trip")
                        .WithMany("TripContents")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.TripEntity", b =>
                {
                    b.HasOne("TripLogServer.Domain.Entities.AppUser", "AppUser")
                        .WithMany("TripEntities")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("Commands");

                    b.Navigation("TripEntities");
                });

            modelBuilder.Entity("TripLogServer.Domain.Entities.TripEntity", b =>
                {
                    b.Navigation("Commands");

                    b.Navigation("TripContents");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using DI.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DI.Test.Data.Migrations
{
    [DbContext(typeof(MsSqlDbContext))]
    [Migration("20230210145950_another one small fix")]
    partial class anotheronesmallfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DI.Test.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DI.Test.Data.Entities.User", b =>
                {
                    b.OwnsOne("DI.Test.Data.Entities.IdValue", "UserId", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("DI.Test.Data.Entities.Location", "Location", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Postcode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("DI.Test.Data.Entities.Coordinates", "Coordinates", b2 =>
                                {
                                    b2.Property<int>("LocationUserId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Latitude")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Longitude")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("LocationUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("LocationUserId");
                                });

                            b1.OwnsOne("DI.Test.Data.Entities.Street", "Street", b2 =>
                                {
                                    b2.Property<int>("LocationUserId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Number")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("LocationUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("LocationUserId");
                                });

                            b1.OwnsOne("DI.Test.Data.Entities.Timezone", "Timezone", b2 =>
                                {
                                    b2.Property<int>("LocationUserId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Offset")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("LocationUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("LocationUserId");
                                });

                            b1.Navigation("Coordinates")
                                .IsRequired();

                            b1.Navigation("Street")
                                .IsRequired();

                            b1.Navigation("Timezone")
                                .IsRequired();
                        });

                    b.OwnsOne("DI.Test.Data.Entities.Login", "Login", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Md5")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Salt")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Sha1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Sha256")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Uuid")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("DI.Test.Data.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("First")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Last")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("DI.Test.Data.Entities.Picture", "Picture", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("DI.Test.Data.Entities.PictureValue", "Large", b2 =>
                                {
                                    b2.Property<int>("PictureUserId")
                                        .HasColumnType("int");

                                    b2.Property<byte[]>("Image")
                                        .HasColumnType("varbinary(max)");

                                    b2.Property<string>("Url")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("PictureUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("PictureUserId");
                                });

                            b1.OwnsOne("DI.Test.Data.Entities.PictureValue", "Medium", b2 =>
                                {
                                    b2.Property<int>("PictureUserId")
                                        .HasColumnType("int");

                                    b2.Property<byte[]>("Image")
                                        .HasColumnType("varbinary(max)");

                                    b2.Property<string>("Url")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("PictureUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("PictureUserId");
                                });

                            b1.OwnsOne("DI.Test.Data.Entities.PictureValue", "Thumbnail", b2 =>
                                {
                                    b2.Property<int>("PictureUserId")
                                        .HasColumnType("int");

                                    b2.Property<byte[]>("Image")
                                        .HasColumnType("varbinary(max)");

                                    b2.Property<string>("Url")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("PictureUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("PictureUserId");
                                });

                            b1.Navigation("Large")
                                .IsRequired();

                            b1.Navigation("Medium")
                                .IsRequired();

                            b1.Navigation("Thumbnail")
                                .IsRequired();
                        });

                    b.OwnsOne("DI.Test.Data.Entities.DateValue", "DoB", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("Age")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("DI.Test.Data.Entities.DateValue", "Registered", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("Age")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("DoB")
                        .IsRequired();

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Picture")
                        .IsRequired();

                    b.Navigation("Registered")
                        .IsRequired();

                    b.Navigation("UserId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

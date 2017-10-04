﻿// <auto-generated />
using FRS.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FRS.DataModel.Migrations
{
    [DbContext(typeof(FRSContext))]
    partial class FRSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FRS.DataModel.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDateTime");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("Discontinued");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("LastModificationUser");

                    b.Property<string>("ProductName");

                    b.Property<int>("UnitPrice");

                    b.Property<int>("UnitsInStock");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FRS.DataModel.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDateTime");

                    b.Property<string>("CreationUser");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("InvalidLoginAttemptsCount");

                    b.Property<bool>("IsLocked");

                    b.Property<bool?>("IsNew");

                    b.Property<bool>("IsRemoved");

                    b.Property<string>("LanguageCulture")
                        .HasMaxLength(16);

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<DateTime?>("LastModificationDateTime");

                    b.Property<string>("LastModificationUser");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("PasswordLastChangedDate");

                    b.Property<string>("Phone")
                        .HasMaxLength(100);

                    b.Property<string>("RemoteUserName")
                        .HasMaxLength(450);

                    b.Property<string>("ResetPasswordHash")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ResetPasswordSendDateTime");

                    b.Property<int?>("RoleId");

                    b.Property<bool>("UseRemoteDirectory");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RemoteUserName")
                        .IsUnique()
                        .HasFilter("[RemoteUserName] IS NOT NULL");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
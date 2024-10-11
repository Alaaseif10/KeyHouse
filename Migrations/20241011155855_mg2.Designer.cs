﻿// <auto-generated />
using System;
using KeyHouse.container;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeyHouse.Migrations
{
    [DbContext(typeof(KeyHouseDB))]
    [Migration("20241011155855_mg2")]
    partial class mg2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BenefitsServicesUnits", b =>
                {
                    b.Property<int>("BenefitsServicesId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("BenefitsServicesId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("BenefitsServicesUnits");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.BenefitsServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BenefitsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BenefitsServices");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Blocks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Block_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CitiesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitiesId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GovernmentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentsId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgenciesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contract_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgenciesId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Governments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Government_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governments");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Img_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitsId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Interest_AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SuccessfulContact")
                        .HasColumnType("bit");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UnitsId");

                    b.HasIndex("UsersId", "UnitsId")
                        .IsUnique();

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Added_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("AgenciesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int?>("BlocksId")
                        .HasColumnType("int");

                    b.Property<bool>("Furnishing")
                        .HasColumnType("bit");

                    b.Property<int?>("Num_Bathrooms")
                        .HasColumnType("int");

                    b.Property<int?>("Num_Rooms")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type_Rent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type_Unit")
                        .HasColumnType("int");

                    b.Property<string>("Under_constracting_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unit_Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciesId");

                    b.HasIndex("BlocksId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AgenciesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciesId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("Users");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Admin", b =>
                {
                    b.HasBaseType("KeyHouse.Models.Entities.Users");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("logo")
                                .HasColumnName("Admin_logo");
                        });

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Agencies", b =>
                {
                    b.HasBaseType("KeyHouse.Models.Entities.Users");

                    b.Property<string>("AgencyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgencyStatus")
                        .HasColumnType("int");

                    b.Property<int>("NumCompany")
                        .HasColumnType("int");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Agencies");
                });

            modelBuilder.Entity("BenefitsServicesUnits", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.BenefitsServices", null)
                        .WithMany()
                        .HasForeignKey("BenefitsServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeyHouse.Models.Entities.Units", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Blocks", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Cities", "Cities")
                        .WithMany("Blocks")
                        .HasForeignKey("CitiesId");

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Cities", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Governments", "Governments")
                        .WithMany("Cities")
                        .HasForeignKey("GovernmentsId");

                    b.Navigation("Governments");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Contracts", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Agencies", "Agencies")
                        .WithMany("Contracts")
                        .HasForeignKey("AgenciesId");

                    b.Navigation("Agencies");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Images", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Units", "Units")
                        .WithMany("Images")
                        .HasForeignKey("UnitsId");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Interest", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Units", "Units")
                        .WithMany("Interests")
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeyHouse.Models.Entities.Users", "Users")
                        .WithMany("Interests")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Units");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Units", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Agencies", "Agencies")
                        .WithMany("Units")
                        .HasForeignKey("AgenciesId");

                    b.HasOne("KeyHouse.Models.Entities.Blocks", "Blocks")
                        .WithMany()
                        .HasForeignKey("BlocksId");

                    b.Navigation("Agencies");

                    b.Navigation("Blocks");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Users", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Agencies", "Agencies")
                        .WithMany()
                        .HasForeignKey("AgenciesId");

                    b.Navigation("Agencies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeyHouse.Models.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KeyHouse.Models.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Cities", b =>
                {
                    b.Navigation("Blocks");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Governments", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Units", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Users", b =>
                {
                    b.Navigation("Interests");
                });

            modelBuilder.Entity("KeyHouse.Models.Entities.Agencies", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}

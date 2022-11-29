﻿// <auto-generated />
using System;
using CourseWorkFactoryAutomatization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CourseWorkFactoryAutomatization.Migrations
{
    [DbContext(typeof(CourseWorkContext))]
    partial class CourseWorkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccountantDetailCatalog", b =>
                {
                    b.Property<long>("AccountantsId")
                        .HasColumnType("bigint");

                    b.Property<long>("DetailCatalogsId")
                        .HasColumnType("bigint");

                    b.HasKey("AccountantsId", "DetailCatalogsId");

                    b.HasIndex("DetailCatalogsId");

                    b.ToTable("AccountantDetailCatalog");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Accountant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accountants");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("IdCatalog")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserCatalogId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserCatalogId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Detail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<long?>("DetailCatalogId")
                        .HasColumnType("bigint");

                    b.Property<long>("TechnicId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DetailCatalogId");

                    b.HasIndex("TechnicId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.DetailCatalog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DetailCatalogs");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.SuperVisor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SuperVisors");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Technic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("TechnicManualId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TechnicManualId");

                    b.ToTable("Technics");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.TechnicManual", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("TechnicManuals");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.UserCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("UserCatalogs");
                });

            modelBuilder.Entity("SuperVisorTechnicManual", b =>
                {
                    b.Property<long>("SuperVisorsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TechnicManualsId")
                        .HasColumnType("bigint");

                    b.HasKey("SuperVisorsId", "TechnicManualsId");

                    b.HasIndex("TechnicManualsId");

                    b.ToTable("SuperVisorTechnicManual");
                });

            modelBuilder.Entity("AccountantDetailCatalog", b =>
                {
                    b.HasOne("CourseWorkFactoryAutomatization.Models.Accountant", null)
                        .WithMany()
                        .HasForeignKey("AccountantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkFactoryAutomatization.Models.DetailCatalog", null)
                        .WithMany()
                        .HasForeignKey("DetailCatalogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Admin", b =>
                {
                    b.HasOne("CourseWorkFactoryAutomatization.Models.UserCatalog", "UserCatalog")
                        .WithMany("Admins")
                        .HasForeignKey("UserCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCatalog");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Detail", b =>
                {
                    b.HasOne("CourseWorkFactoryAutomatization.Models.DetailCatalog", null)
                        .WithMany("Details")
                        .HasForeignKey("DetailCatalogId");

                    b.HasOne("CourseWorkFactoryAutomatization.Models.Technic", "Technic")
                        .WithMany("Details")
                        .HasForeignKey("TechnicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technic");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Technic", b =>
                {
                    b.HasOne("CourseWorkFactoryAutomatization.Models.TechnicManual", null)
                        .WithMany("Technics")
                        .HasForeignKey("TechnicManualId");
                });

            modelBuilder.Entity("SuperVisorTechnicManual", b =>
                {
                    b.HasOne("CourseWorkFactoryAutomatization.Models.SuperVisor", null)
                        .WithMany()
                        .HasForeignKey("SuperVisorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWorkFactoryAutomatization.Models.TechnicManual", null)
                        .WithMany()
                        .HasForeignKey("TechnicManualsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.DetailCatalog", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.Technic", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.TechnicManual", b =>
                {
                    b.Navigation("Technics");
                });

            modelBuilder.Entity("CourseWorkFactoryAutomatization.Models.UserCatalog", b =>
                {
                    b.Navigation("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}

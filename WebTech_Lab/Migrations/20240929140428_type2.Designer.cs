﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTech_Lab.Data;

#nullable disable

namespace WebTech_Lab.Migrations
{
    [DbContext(typeof(WebTechLabContext))]
    [Migration("20240929140428_type2")]
    partial class type2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebTech_Lab.Data.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<string>("EnemyDamage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyHealth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnemyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("EnemyId");

                    b.HasIndex("EnemyTypeId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("WebTech_Lab.Data.EnemyType", b =>
                {
                    b.Property<int>("EnemyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyTypeId"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnemyTypeId");

                    b.ToTable("EnemyTypes");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int?>("EnemyId")
                        .HasColumnType("int");

                    b.Property<string>("GameDiscription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("EnemyId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhotoId"));

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Enemy", b =>
                {
                    b.HasOne("WebTech_Lab.Data.EnemyType", "EnemyType")
                        .WithMany("Enemies")
                        .HasForeignKey("EnemyTypeId");

                    b.HasOne("WebTech_Lab.Data.Photo", "Photo")
                        .WithMany("Enemies")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnemyType");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Game", b =>
                {
                    b.HasOne("WebTech_Lab.Data.Enemy", "Enemy")
                        .WithMany("Games")
                        .HasForeignKey("EnemyId");

                    b.HasOne("WebTech_Lab.Data.Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Enemy");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Player", b =>
                {
                    b.HasOne("WebTech_Lab.Data.Photo", "Photo")
                        .WithMany("Players")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Enemy", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("WebTech_Lab.Data.EnemyType", b =>
                {
                    b.Navigation("Enemies");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Photo", b =>
                {
                    b.Navigation("Enemies");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("WebTech_Lab.Data.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}

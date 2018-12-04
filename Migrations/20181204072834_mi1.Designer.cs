﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieContexts.Models;

namespace Gprojet.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20181204072834_mi1")]
    partial class mi1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Exigeance_Taches.Models.Exigeance_Tache", b =>
                {
                    b.Property<int>("Exigeance_TacheID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExigeanceID");

                    b.Property<int>("TacheID");

                    b.HasKey("Exigeance_TacheID");

                    b.HasIndex("ExigeanceID");

                    b.HasIndex("TacheID");

                    b.ToTable("Exigeance_Tache");
                });

            modelBuilder.Entity("Exigeances.Models.Exigeance", b =>
                {
                    b.Property<int>("ExigeanceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjetID");

                    b.Property<int>("TypeExigeanceID");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("nom")
                        .IsRequired();

                    b.HasKey("ExigeanceID");

                    b.HasIndex("ProjetID");

                    b.HasIndex("TypeExigeanceID");

                    b.ToTable("Exigeance");
                });

            modelBuilder.Entity("Jalons.Models.Jalon", b =>
                {
                    b.Property<int>("JalonID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjetiD");

                    b.Property<int>("RespID");

                    b.Property<DateTime?>("datefinprevue");

                    b.Property<string>("nom")
                        .IsRequired();

                    b.HasKey("JalonID");

                    b.HasIndex("ProjetiD");

                    b.HasIndex("RespID");

                    b.ToTable("jalon");
                });

            modelBuilder.Entity("Projets.Models.Projet", b =>
                {
                    b.Property<int>("ProjetID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RespID");

                    b.Property<string>("description");

                    b.Property<string>("nom");

                    b.Property<string>("trigrame")
                        .HasMaxLength(3);

                    b.HasKey("ProjetID");

                    b.HasIndex("RespID");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("Resps.Models.Resp", b =>
                {
                    b.Property<int>("RespID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nom");

                    b.HasKey("RespID");

                    b.ToTable("resp");
                });

            modelBuilder.Entity("Taches.Models.Tache", b =>
                {
                    b.Property<int>("TacheID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("JalonID");

                    b.Property<int>("RespID");

                    b.Property<int?>("TachePreceTacheID");

                    b.Property<DateTime?>("datedebuttache");

                    b.Property<DateTime>("datedemarage");

                    b.Property<DateTime?>("datefintache");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<int>("nbjours");

                    b.Property<string>("nom")
                        .IsRequired();

                    b.HasKey("TacheID");

                    b.HasIndex("JalonID");

                    b.HasIndex("RespID");

                    b.HasIndex("TachePreceTacheID");

                    b.ToTable("taches");
                });

            modelBuilder.Entity("TypeExigeances.Models.TypeExigeance", b =>
                {
                    b.Property<int>("TypeExigeanceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProjetID");

                    b.Property<string>("nom")
                        .IsRequired();

                    b.HasKey("TypeExigeanceID");

                    b.HasIndex("ProjetID");

                    b.ToTable("TypeExigeance");
                });

            modelBuilder.Entity("Exigeance_Taches.Models.Exigeance_Tache", b =>
                {
                    b.HasOne("Exigeances.Models.Exigeance", "Exigeance")
                        .WithMany("Exigeance_Tache")
                        .HasForeignKey("ExigeanceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taches.Models.Tache", "Tache")
                        .WithMany("Exigeance_Tache")
                        .HasForeignKey("TacheID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Exigeances.Models.Exigeance", b =>
                {
                    b.HasOne("Projets.Models.Projet", "Projet")
                        .WithMany("Exigeance")
                        .HasForeignKey("ProjetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TypeExigeances.Models.TypeExigeance", "TypeExigeance")
                        .WithMany("Exigeance")
                        .HasForeignKey("TypeExigeanceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jalons.Models.Jalon", b =>
                {
                    b.HasOne("Projets.Models.Projet", "Projet")
                        .WithMany("Jalon")
                        .HasForeignKey("ProjetiD")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Resps.Models.Resp", "Resp")
                        .WithMany("Jalon")
                        .HasForeignKey("RespID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Projets.Models.Projet", b =>
                {
                    b.HasOne("Resps.Models.Resp", "resp")
                        .WithMany("Projet")
                        .HasForeignKey("RespID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taches.Models.Tache", b =>
                {
                    b.HasOne("Jalons.Models.Jalon", "Jalons")
                        .WithMany("Tache")
                        .HasForeignKey("JalonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Resps.Models.Resp", "Resps")
                        .WithMany("Tache")
                        .HasForeignKey("RespID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taches.Models.Tache", "TachePrece")
                        .WithMany()
                        .HasForeignKey("TachePreceTacheID");
                });

            modelBuilder.Entity("TypeExigeances.Models.TypeExigeance", b =>
                {
                    b.HasOne("Projets.Models.Projet", "Projet")
                        .WithMany()
                        .HasForeignKey("ProjetID");
                });
#pragma warning restore 612, 618
        }
    }
}
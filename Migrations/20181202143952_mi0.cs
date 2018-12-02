﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medecins.Migrations
{
    public partial class mi0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    MedecinID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.MedecinID);
                });

            migrationBuilder.CreateTable(
                name: "resp",
                columns: table => new
                {
                    RespID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resp", x => x.RespID);
                });

            migrationBuilder.CreateTable(
                name: "salles",
                columns: table => new
                {
                    SalleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salles", x => x.SalleID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true),
                    MedecinID = table.Column<int>(nullable: true),
                    datenaissance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Medecins_MedecinID",
                        column: x => x.MedecinID,
                        principalTable: "Medecins",
                        principalColumn: "MedecinID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    ProjetID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true),
                    trigrame = table.Column<string>(maxLength: 3, nullable: true),
                    description = table.Column<string>(nullable: true),
                    RespID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ProjetID);
                    table.ForeignKey(
                        name: "FK_Projets_resp_RespID",
                        column: x => x.RespID,
                        principalTable: "resp",
                        principalColumn: "RespID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rdvs",
                columns: table => new
                {
                    RdvID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateRdv = table.Column<DateTime>(nullable: false),
                    FinDateRdv = table.Column<DateTime>(nullable: false),
                    MedecinId = table.Column<int>(nullable: false),
                    SalleId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rdvs", x => x.RdvID);
                    table.ForeignKey(
                        name: "FK_Rdvs_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "MedecinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rdvs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rdvs_salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "salles",
                        principalColumn: "SalleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jalon",
                columns: table => new
                {
                    JalonID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: false),
                    ProjetiD = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jalon", x => x.JalonID);
                    table.ForeignKey(
                        name: "FK_jalon_Projets_ProjetiD",
                        column: x => x.ProjetiD,
                        principalTable: "Projets",
                        principalColumn: "ProjetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeExigeance",
                columns: table => new
                {
                    TypeExigeanceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: false),
                    ProjetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeExigeance", x => x.TypeExigeanceID);
                    table.ForeignKey(
                        name: "FK_TypeExigeance_Projets_ProjetID",
                        column: x => x.ProjetID,
                        principalTable: "Projets",
                        principalColumn: "ProjetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "taches",
                columns: table => new
                {
                    TacheID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    datedemarage = table.Column<DateTime>(nullable: false),
                    TachePreceTacheID = table.Column<int>(nullable: true),
                    nbjours = table.Column<int>(nullable: false),
                    RespsRespID = table.Column<int>(nullable: true),
                    datedebuttache = table.Column<DateTime>(nullable: true),
                    datefintache = table.Column<DateTime>(nullable: true),
                    JalonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taches", x => x.TacheID);
                    table.ForeignKey(
                        name: "FK_taches_jalon_JalonID",
                        column: x => x.JalonID,
                        principalTable: "jalon",
                        principalColumn: "JalonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taches_resp_RespsRespID",
                        column: x => x.RespsRespID,
                        principalTable: "resp",
                        principalColumn: "RespID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_taches_taches_TachePreceTacheID",
                        column: x => x.TachePreceTacheID,
                        principalTable: "taches",
                        principalColumn: "TacheID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exigeance",
                columns: table => new
                {
                    ExigeanceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    ProjetID = table.Column<int>(nullable: false),
                    TypeExigeanceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exigeance", x => x.ExigeanceID);
                    table.ForeignKey(
                        name: "FK_Exigeance_Projets_ProjetID",
                        column: x => x.ProjetID,
                        principalTable: "Projets",
                        principalColumn: "ProjetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exigeance_TypeExigeance_TypeExigeanceID",
                        column: x => x.TypeExigeanceID,
                        principalTable: "TypeExigeance",
                        principalColumn: "TypeExigeanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exigeance_Tache",
                columns: table => new
                {
                    Exigeance_TacheID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExigeanceID = table.Column<int>(nullable: false),
                    TacheID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exigeance_Tache", x => x.Exigeance_TacheID);
                    table.ForeignKey(
                        name: "FK_Exigeance_Tache_Exigeance_ExigeanceID",
                        column: x => x.ExigeanceID,
                        principalTable: "Exigeance",
                        principalColumn: "ExigeanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exigeance_Tache_taches_TacheID",
                        column: x => x.TacheID,
                        principalTable: "taches",
                        principalColumn: "TacheID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exigeance_ProjetID",
                table: "Exigeance",
                column: "ProjetID");

            migrationBuilder.CreateIndex(
                name: "IX_Exigeance_TypeExigeanceID",
                table: "Exigeance",
                column: "TypeExigeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Exigeance_Tache_ExigeanceID",
                table: "Exigeance_Tache",
                column: "ExigeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Exigeance_Tache_TacheID",
                table: "Exigeance_Tache",
                column: "TacheID");

            migrationBuilder.CreateIndex(
                name: "IX_jalon_ProjetiD",
                table: "jalon",
                column: "ProjetiD");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedecinID",
                table: "Patients",
                column: "MedecinID");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_RespID",
                table: "Projets",
                column: "RespID");

            migrationBuilder.CreateIndex(
                name: "IX_Rdvs_MedecinId",
                table: "Rdvs",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Rdvs_PatientId",
                table: "Rdvs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rdvs_SalleId",
                table: "Rdvs",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_taches_JalonID",
                table: "taches",
                column: "JalonID");

            migrationBuilder.CreateIndex(
                name: "IX_taches_RespsRespID",
                table: "taches",
                column: "RespsRespID");

            migrationBuilder.CreateIndex(
                name: "IX_taches_TachePreceTacheID",
                table: "taches",
                column: "TachePreceTacheID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeExigeance_ProjetID",
                table: "TypeExigeance",
                column: "ProjetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exigeance_Tache");

            migrationBuilder.DropTable(
                name: "Rdvs");

            migrationBuilder.DropTable(
                name: "Exigeance");

            migrationBuilder.DropTable(
                name: "taches");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "salles");

            migrationBuilder.DropTable(
                name: "TypeExigeance");

            migrationBuilder.DropTable(
                name: "jalon");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "resp");
        }
    }
}

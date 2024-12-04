using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebahotel.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    id_hotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    horarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.id_hotel);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumTel = table.Column<int>(type: "int", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "habitaciones",
                columns: table => new
                {
                    Id_habitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_hotel = table.Column<int>(type: "int", nullable: false),
                    Numero_habitacion = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    precio_noche = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hotelid_hotel1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habitaciones", x => x.Id_habitacion);
                    table.ForeignKey(
                        name: "FK_habitaciones_hotels_Hotelid_hotel1",
                        column: x => x.Hotelid_hotel1,
                        principalTable: "hotels",
                        principalColumn: "id_hotel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_habitaciones_hotels_id_hotel",
                        column: x => x.id_hotel,
                        principalTable: "hotels",
                        principalColumn: "id_hotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    id_reservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_pagado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.id_reservacion);
                    table.ForeignKey(
                        name: "FK_Reservaciones_usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesReservacion",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesReservacion", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesReservacion_habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "habitaciones",
                        principalColumn: "Id_habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesReservacion_Reservaciones_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reservaciones",
                        principalColumn: "id_reservacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservacion_IdHabitacion",
                table: "DetallesReservacion",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesReservacion_IdReserva",
                table: "DetallesReservacion",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_habitaciones_Hotelid_hotel1",
                table: "habitaciones",
                column: "Hotelid_hotel1");

            migrationBuilder.CreateIndex(
                name: "IX_habitaciones_id_hotel",
                table: "habitaciones",
                column: "id_hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_IdUsuario",
                table: "Reservaciones",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesReservacion");

            migrationBuilder.DropTable(
                name: "habitaciones");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}

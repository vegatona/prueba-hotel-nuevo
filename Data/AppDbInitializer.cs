using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using pruebahotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data
{
    public class AppDbInitializer
    {
        //metodo que agrega datos a la base de datos
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //hoteles
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.hotels.Any())
                {
                    context.hotels.AddRange(new Hotel()
                    {
                        nombre = "1st hotel",
                        direccion = "1st direccion",
                        telefono = 4456122,
                        horarios = DateTime.Now.AddDays(-10),
                        descripcion = "bonito",
                    },
                    new Hotel()
                    {
                        nombre = "2nd hotel",
                        direccion = "2nd direccion",
                        telefono = 563360125,
                        horarios = DateTime.Now.AddDays(-10),
                        descripcion = "malo",
                    });
                    context.SaveChanges();
                }
                //habitaciones
                if (!context.habitaciones.Any())
                {
                    context.habitaciones.AddRange(new Habitacion()
                    {
                        Numero_habitacion = 101,
                        tipo = "suit",
                        capacidad = 4,
                        precio_noche = 250,
                        estado = "disponible",
                    },
                    new Habitacion()
                    {
                        Numero_habitacion = 201,
                        tipo = "basica",
                        capacidad = 2,
                        precio_noche = 170,
                        estado = "ocupada",
                    },
                    new Habitacion()
                    {
                        Numero_habitacion = 301,
                        tipo = "sencilla",
                        capacidad = 1,
                        precio_noche = 87,
                        estado = "mantenimiento",
                    });
                    context.SaveChanges();
                }
                //reservaciones
                if (!context.Reservaciones.Any())
                {
                    context.Reservaciones.AddRange(new reservaciones()
                    {
                        id_habitacion = 1,
                        fecha_inicio = DateTime.Now.AddDays(-10),
                        fecha_final = DateTime.Now.AddDays(-10),
                        estado = "cancelada",
                    },
                    new reservaciones()
                    {
                        id_habitacion = 2,
                        fecha_inicio = DateTime.Now.AddDays(-10),
                        fecha_final = DateTime.Now.AddDays(-10),
                        estado = "confirmada",
                    },
                    new reservaciones()
                    {
                        id_habitacion = 3,
                        fecha_inicio = DateTime.Now.AddDays(-10),
                        fecha_final = DateTime.Now.AddDays(-10),
                        estado = "pendiente",
                    });
                    context.SaveChanges();
                }
                //usuarios
                if (!context.usuarios.Any())
                {
                    context.usuarios.AddRange(new Usuario()
                    {
                        nombre = "1st nombre",
                        apellido = "1st apellido",
                        NumTel = 64456122,
                        rol = "administrador",
                        password = "123",
                    },
                    new Usuario()
                    {
                        nombre = "2nd nombre",
                        apellido = "2nd apellido",
                        NumTel = 644636025,
                        rol = "cliente",
                        password = "abc",
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

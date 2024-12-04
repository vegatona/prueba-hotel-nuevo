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
                        horarios = "Check-in: 14:00, Check-out: 12:00",
                        descripcion = "bonito",
                    },
                    new Hotel()
                    {
                        nombre = "2nd hotel",
                        direccion = "2nd direccion",
                        telefono = 563360125,
                        horarios = "Check-in: 1:00, Check-out: 1:00",
                        descripcion = "malo",
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

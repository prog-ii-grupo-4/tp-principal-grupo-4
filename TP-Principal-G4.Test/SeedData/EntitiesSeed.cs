using TP_Principal_G4.Entities;

namespace TP_Principal_G4.Test.SeedData
{
    internal class EntitiesSeed
    {
        public static List<Raza> GenerateRazas()
        {
            List<Raza> razas = new List<Raza>()
            {
                new Raza
                {
                    Id = 1,
                    Nombre = "San bernardo"
                },
                new Raza
                {
                    Id = 2,
                    Nombre = "Labrador retriever"
                },
                new Raza
                {
                    Id = 3,
                    Nombre = "Gato persa"
                },
                new Raza
                {
                    Id = 4,
                    Nombre = "Gato siamés"
                }
            };

            return razas;
        }

        public static List<Refugio> GenerateRefugios()
        {
            List<Refugio> refugios = new List<Refugio>()
            {
                new Refugio
                {
                    Id = 1,
                    Nombre = "Santuario animal",
                    RazonSocial = "Santuario animal S.A.",
                    NombreDelResponsable = "Jorge",
                    ApellidoDelResponsable = "Pérez"
                }
            };

            return refugios;
        }

        public static List<Animal> GenerateAnimales()
        {
            List<Animal> animales = new List<Animal>()
            {
                new Animal
                {
                    Id = 1,
                    Nombre = "Pancho",
                    Genero = 'M',
                    Especie = "perro",
                    Color = "negro",
                    Peso = 10, // en kg.
                    Altura = 25, // en cm.
                    Edad = 2,
                    FechaDeIngreso = DateTime.Now,
                    Descripcion = "Es un perro muy cariñoso y tranquilo.",
                    Id_Raza = 2,
                    Id_Refugio = 1
                },
                new Animal
                {
                    Id = 2,
                    Nombre = "Luna",
                    Genero = 'H',
                    Especie = "perro",
                    Color = "blanco",
                    Peso = 7, // en kg.
                    Altura = 5, // en cm.
                    Edad = 1,
                    FechaDeIngreso = DateTime.Now,
                    Descripcion = "Es muy juguetona.",
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal
                {
                    Id = 3,
                    Nombre = "Mia",
                    Genero = 'H',
                    Especie = "gato",
                    Color = "negro",
                    Peso = 20, // en kg.
                    Altura = 15, // en cm.
                    Edad = 4,
                    FechaDeIngreso = DateTime.Now,
                    Descripcion = "Siempre está en movimiento.",
                    Id_Raza = 4,
                    Id_Refugio = 1
                },
                new Animal
                {
                    Id = 4,
                    Nombre = "Felix",
                    Genero = 'M',
                    Especie = "gato",
                    Color = "blanco",
                    Peso = 5, // en kg.
                    Altura = 8, // en cm.
                    Edad = 1,
                    FechaDeIngreso = DateTime.Now,
                    Descripcion = "Duerme mucho.",
                    Id_Raza = 3,
                    Id_Refugio = 1
                }
            };

            return animales;
        }
    }
}

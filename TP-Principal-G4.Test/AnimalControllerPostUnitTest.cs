using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Principal_G4.Controllers;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Repositories;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Test
{
    public class AnimalControllerPostUnitTest
    {
        private IAnimalRepository _animalRepository;

        public AnimalControllerPostUnitTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TpPrincipalG4Context>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            var context = new TpPrincipalG4Context(dbContextOptions);
            DbContextUtils.SeedData(context);

            _animalRepository = new AnimalRepository(context);
        }

        //[Fact(DisplayName = "CreateAnimal_OK")]
        public async void Task_Create_Animal_Return_OkResult()
        {
            //Arrange  
            var controller = new AnimalController(_animalRepository);

            var newAnimal = new AnimalDTO()
            {
                Nombre = "Prueba",
                Genero = "M", // o "F" para hembra
                Peso = 10,
                Altura = 60,
                Descripcion = "Un perro de prueba.",
                Color = "blanco",
                Edad = 3,
                Especie = "perro",
                FechaDeIngreso = DateTime.Now,
                Id_Raza = 1, // Debe coincidir con la raza creada en memoria
                Id_Refugio = 1, // Debe coincidir con el refugio creado en memoria
            };

            //Act  
            var data = await controller.CreateAnimal(newAnimal);

            //Assert  
            Assert.IsType<CreatedAtActionResult>(data);

            var createdResult = data as CreatedAtActionResult;
            Assert.NotNull(createdResult); // verifico que la llamada devolvió un Created 201

            var createdAnimal = createdResult.Value as ShowAnimalDTO;
            Assert.NotNull(createdAnimal); // obtengo el objeto de respuesta

            Assert.Equal(newAnimal.Nombre, createdAnimal.Nombre); // compruebo que el nombre del animal creado es igual al enviado
            Assert.Equal(Convert.ToChar(newAnimal.Genero), createdAnimal.Genero); // compruebo que el género del animal creado es igual al enviado
            Assert.Equal(newAnimal.Color, createdAnimal.Color);
            Assert.Equal(newAnimal.Especie, createdAnimal.Especie);
        }

        //[Fact(DisplayName = "CreateAnimal_BadRequest")]
        public async void Task_Create_Animal_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new AnimalController(_animalRepository);

            var newAnimal = new AnimalDTO()
            {
                Nombre = "Pancho", // mismo nombre de un animal ya creado
                Genero = "macho", // escribo varios caracteres en vez de H o M
                Especie = "perro",
                Color = "negro",
                Peso = 10, // en kg.
                Altura = 25, // en cm.
                Edad = 2,
                FechaDeIngreso = DateTime.Now,
                Descripcion = "Es un animal muy bueno.",
                Id_Raza = 2,
                Id_Refugio = 1
            };

            //Act  
            var data = await controller.CreateAnimal(newAnimal);

            //Assert  
            Assert.IsType<BadRequestObjectResult>(data); // verifico que llamada devolvió un BadRequest 400
        }
    }
}

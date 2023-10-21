using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Moq;
using TP_Principal_G4.Controllers;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Repositories;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Test
{
    public class AnimalControllerUnitTest
    {
        private TpPrincipalG4Context _context;
        private IAnimalRepository _animalRepository;

        public AnimalControllerUnitTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TpPrincipalG4Context>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new TpPrincipalG4Context(dbContextOptions);
            DbContextUtils.SeedData(_context);

            _animalRepository = new AnimalRepository(_context);
        }

        [Fact(DisplayName = "GetAnimales_OK")]
        public async void Task_GetAnimales_Return_OkResult()
        {
            //Arrange  
            var controller = new AnimalController(_animalRepository);

            //Act  
            var data = await controller.GetAnimales();

            //Assert
            Assert.IsType<OkObjectResult>(data); // compruebo que la llamada al método GetAnimales del controlador devolvió OK 200
        }

        [Fact(DisplayName = "GetAnimalesCount_OK")]
        public async void Task_GetAnimales_MatchResult()
        {
            //Arrange  
            var controller = new AnimalController(_animalRepository);

            //Act  
            var data = await controller.GetAnimales();

            //Assert
            var okObjectResult = data as OkObjectResult; // casteo 'data' a su clase concreta OkObjectResult
            Assert.NotNull(okObjectResult); // verifico que la llamada devolvió un OK 200

            var animales = okObjectResult.Value as List<ShowAnimalDTO>;
            Assert.NotNull(animales); // verifico que el objeto resultante es del tipo ShowAnimalDTO

            Assert.Equal(4, animales.Count); // compruebo que devuelve los 4 animales pre-cargados
        }

        [Fact(DisplayName = "GetAnimal_OK")]
        public async void Task_GetAnimal_Return_OkResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 1;

            //Act
            var data = await controller.GetAnimal(animalId);

            Assert.IsType<OkObjectResult>(data); // compruebo que devuelve el animal con id 1
        }

        [Fact(DisplayName = "GetAnimal_NotFound")]
        public async void Task_GetAnimal_Return_NotFoundResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 88; // id de animal que aún no existe

            //Act
            var data = await controller.GetAnimal(animalId);

            Assert.IsType<NotFoundResult>(data); // compruebo que no encontró el animal
        }

        [Fact(DisplayName = "CreateAnimal_OK")]
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
            Assert.NotNull(createdAnimal); // verifico el tipo de objeto de respuesta

            Assert.Equal(newAnimal.Nombre, createdAnimal.Nombre); // compruebo que el nombre del animal creado es igual al enviado
            Assert.Equal(Convert.ToChar(newAnimal.Genero), createdAnimal.Genero); // compruebo que el género del animal creado es igual al enviado
            Assert.Equal(newAnimal.Color, createdAnimal.Color);
            Assert.Equal(newAnimal.Especie, createdAnimal.Especie);
        }

        [Fact(DisplayName = "CreateAnimal_BadRequest")]
        public async void Task_Create_Animal_Return_BadRequestResult()
        {
            //Arrange  
            AnimalController controller = new AnimalController(_animalRepository);

            AnimalDTO newAnimal = new AnimalDTO()
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

        [Fact(DisplayName = "UpdateAnimal_NoContent")]
        public async void Task_Update_Animal_Return_NoContentResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 3;

            //Act
            var response = await controller.GetAnimal(animalId);

            OkObjectResult? okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult); // verifico que encontró al animal con id 3

            ShowAnimalDTO? existingAnimal = okObjectResult.Value as ShowAnimalDTO;
            Assert.NotNull(existingAnimal); // obtengo los datos del animal con id 3

            var raza = await _context.Razas.FirstOrDefaultAsync(r => r.Nombre.Equals(existingAnimal.Raza));
            var refugio = await _context.Refugios.FirstOrDefaultAsync(r => r.Nombre.Equals(existingAnimal.Refugio));

            AnimalDTO editedAnimal = new AnimalDTO()
            {
                Nombre = "Lucy",
                Edad = 7,
                Peso = 40,
                Altura = 25,
                Genero = existingAnimal.Genero.ToString(),
                Descripcion = existingAnimal.Descripcion,
                Color = existingAnimal.Color,
                Especie = existingAnimal.Especie,
                FechaDeIngreso = existingAnimal.FechaDeIngreso,
                Id_Raza = raza!.Id,
                Id_Refugio = refugio!.Id,
            };

            var data = await controller.UpdateAnimal(animalId, editedAnimal);

            // Assert
            Assert.IsType<NoContentResult>(data); // verifico que actualizo el animal
        }

        [Fact(DisplayName = "UpdateAnimal_BadRequest")]
        public async void Task_Update_Animal_Return_BadRequestResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 3;

            //Act
            var response = await controller.GetAnimal(animalId);

            OkObjectResult? okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult); // verifico que encontró al animal con id 3

            ShowAnimalDTO? existingAnimal = okObjectResult.Value as ShowAnimalDTO;
            Assert.NotNull(existingAnimal); // obtengo los datos del animal con id 3

            AnimalDTO editedAnimal = new AnimalDTO()
            {
                Nombre = "Lucy",
                Edad = 7,
                Peso = 40,
                Altura = 25,
                Genero = existingAnimal.Genero.ToString(),
                Descripcion = existingAnimal.Descripcion,
                Color = existingAnimal.Color,
                Especie = existingAnimal.Especie,
                FechaDeIngreso = existingAnimal.FechaDeIngreso,
                Id_Raza = 99, // establezco un id de raza que no existe aún
                Id_Refugio = 88, // establezco un id de refugio que no existe aún
            };

            var data = await controller.UpdateAnimal(animalId, editedAnimal);

            // Assert
            Assert.IsType<BadRequestObjectResult>(data); // verifico que falló al actualizar y arrojó un error 400
        }

        [Fact(DisplayName = "DeleteAnimal_NoContent")]
        public async void Task_Delete_Animal_Return_NoContentResult()
        {
            //Arrange  
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 2; // id de animal a borrar

            //Act  
            var data = await controller.DeleteAnimal(animalId);

            //Assert  
            Assert.IsType<NoContentResult>(data); // verifico que elimino al animal
        }

        [Fact(DisplayName = "DeleteAnimal_NotFound")]
        public async void Task_Delete_Animal_Return_NotFoundResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            int animalId = 99; // id de animal que aún no existe

            //Act
            var data = await controller.DeleteAnimal(animalId);

            //Assert
            Assert.IsType<NotFoundResult>(data); // verifico que no encontró el id del animal enviado
        }

        [Fact(DisplayName = "SearchAnimales_OK")]
        public async void Task_Search_Animal_Return_OkResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            string color = "negro"; // color de los animales a buscar
            string especie = "perro"; // especie de animales a buscar

            //Act
            var data = await controller.Search(color, especie);

            //Assert
            var okObjectResult = data as OkObjectResult;
            Assert.NotNull(okObjectResult); // verifico que devuelve OK con los animales encontrados según los filtros

            var animalesEncontrados = okObjectResult.Value as List<ShowAnimalDTO>;
            Assert.NotNull(animalesEncontrados); // obtengo el listado de animales encontrados

            // compruebo que la cantidad de animales encontrados cumple correctamente con los filtros de búsqueda
            IEnumerable<ShowAnimalDTO> animalesEsperados = animalesEncontrados.Where(a => a.Color.Equals(color) && a.Especie.Equals(especie));
            Assert.Equal(animalesEsperados.Count(), animalesEncontrados.Count());
        }

        [Fact(DisplayName = "SearchAnimalesByColor_OK")]
        public async void Task_Search_Animal_By_Color_Return_OkResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            string color = "negro"; // color de los animales a buscar
            string especie = string.Empty; // no especifico ninguna especie

            //Act
            var data = await controller.Search(color, especie);

            //Assert
            var okObjectResult = data as OkObjectResult;
            Assert.NotNull(okObjectResult); // verifico que devuelve OK con los animales encontrados según los filtros

            var animalesEncontrados = okObjectResult.Value as List<ShowAnimalDTO>;
            Assert.NotNull(animalesEncontrados); // obtengo el listado de animales encontrados

            // compruebo que la cantidad de animales encontrados son del color buscado
            IEnumerable<ShowAnimalDTO> animalesEsperados = animalesEncontrados.Where(a => a.Color.Equals(color));
            Assert.Equal(animalesEsperados.Count(), animalesEncontrados.Count());
        }

        [Fact(DisplayName = "SearchAnimalesByEspecie_OK")]
        public async void Task_Search_Animal_By_Especie_Return_OkResult()
        {
            //Arrange
            AnimalController controller = new AnimalController(_animalRepository);
            string color = string.Empty; // no especifico ningún color
            string especie = "perro"; // especie de animales a buscar

            //Act
            var data = await controller.Search(color, especie);

            //Assert
            var okObjectResult = data as OkObjectResult;
            Assert.NotNull(okObjectResult); // verifico que devuelve OK con los animales encontrados según los filtros

            var animalesEncontrados = okObjectResult.Value as List<ShowAnimalDTO>;
            Assert.NotNull(animalesEncontrados); // obtengo el listado de animales encontrados

            // compruebo que la cantidad de animales encontrados son de la especie buscada
            IEnumerable<ShowAnimalDTO> animalesEsperados = animalesEncontrados.Where(a => a.Especie.Equals(especie));
            Assert.Equal(animalesEsperados.Count(), animalesEncontrados.Count());
        }
    }
}
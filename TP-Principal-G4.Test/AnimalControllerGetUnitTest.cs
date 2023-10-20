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
    public class AnimalControllerGetUnitTest : AnimalControllerBaseUnitTest
    {
        private IAnimalRepository _animalRepository;

        public AnimalControllerGetUnitTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TpPrincipalG4Context>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            var context = new TpPrincipalG4Context(dbContextOptions);
            DbContextUtils.SeedData(context);

            _animalRepository = new AnimalRepository(context);
        }

        //[Fact(DisplayName = "GetAnimales_OK")]
        public async void Task_GetAnimales_Return_OkResult()
        {
            //Arrange  
            var controller = new AnimalController(_animalRepository);

            //Act  
            var data = await controller.GetAnimales();

            //Assert
            Assert.IsType<OkObjectResult>(data); // compruebo que la llamada al método GetAnimales del controlador devolvió OK 200
        }

        //[Fact(DisplayName = "GetAnimales_OKCount")]
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
    }
}

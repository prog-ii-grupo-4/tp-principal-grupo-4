using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Repositories;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Controllers
{
    [ApiController]
    [Route("api/animales")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimales()
        {
            IEnumerable<MostrarAnimalesDTO> animales = await _animalRepository.GetAllAnimals();

            if(animales.Count() > 0)
            {
                return Ok(animales);
            }

            return NotFound("No hay ningún animal que mostrar.");
        }

        // POST /api/animales
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimalDTO animalDto)
        {
            try
            {
                await _animalRepository.Create(this.DtoToAnimal(animalDto));
                return Ok("Animal creado exitosamente.");
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un problema al crear el animal. Causa: ";

                if(ex is SqlException | ex is DbUpdateException)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    return BadRequest(errorMessage + ex.InnerException.Message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                return BadRequest(errorMessage + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] EditAnimalDTO animalDto)
        {
            try
            {
                await _animalRepository.Update(this.EditAnimalDtoToAnimal(animalDto));
                return Ok("El animal " + animalDto.Nombre + " con id '" + animalDto.Id + "' fue editado exitosamente.");
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocurrió un problema al editar el animal. Causa: ";

                if (ex is SqlException | ex is DbUpdateException)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    return BadRequest(errorMessage + ex.InnerException.Message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                return BadRequest(errorMessage + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            try
            {
                if(id > 0)
                {
                    await _animalRepository.Delete(id);
                    return NoContent();
                }

                return BadRequest("El id de animal no es válido.");
            }
            catch (Exception ex)
            {
                string errorMessage = "No se pudo eliminar al animal. Causa: ";

                if (ex is SqlException | ex is DbUpdateException)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    return BadRequest(errorMessage + ex.InnerException.Message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                return BadRequest(errorMessage + ex.Message);
            }
        }

        [HttpGet]
        [Route("razas")]
        public async Task<IActionResult> GetAllRazas()
        {
            IEnumerable<Raza> razas = await _animalRepository.GetAllRazas();

            if (razas.Any())
                return Ok(razas);

            return NotFound("No hay cargada ninguna raza en la base de datos.");
        }

        private Animal DtoToAnimal(CreateAnimalDTO animalDto)
        {
            return new Animal
            {
                Nombre = animalDto.Nombre,
                Genero = animalDto.Genero,
                Peso = animalDto.Peso,
                Altura = animalDto.Altura,
                Descripcion = animalDto.Descripcion,
                Color = animalDto.Color,
                Edad = animalDto.Edad,
                Especie = animalDto.Especie,
                FechaDeIngreso = animalDto.FechaDeIngreso,
                Id_Raza = animalDto.Id_Raza,
                Id_Refugio = animalDto.Id_Refugio,
            };
        }

        private Animal EditAnimalDtoToAnimal(EditAnimalDTO animalDto)
        {
            return new Animal
            {
                Id = animalDto.Id,
                Nombre = animalDto.Nombre,
                Genero = animalDto.Genero,
                Peso = animalDto.Peso,
                Altura = animalDto.Altura,
                Descripcion = animalDto.Descripcion,
                Color = animalDto.Color,
                Edad = animalDto.Edad,
                Especie = animalDto.Especie,
                FechaDeIngreso = animalDto.FechaDeIngreso,
                Id_Raza = animalDto.Id_Raza,
                Id_Refugio = animalDto.Id_Refugio,
            };
        }
    }
}

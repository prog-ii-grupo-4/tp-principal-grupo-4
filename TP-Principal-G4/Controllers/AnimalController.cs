using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TP_Principal_G4.DTOs;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Exceptions;
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

        // GET /api/animales/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAnimal([FromRoute] int id)
        {
            ShowAnimalDTO animal = await _animalRepository.GetAnimal(id);

            if (animal != null)
                return Ok(animal);

            return NotFound();
        }

        // GET /api/animales
        [HttpGet]
        public async Task<IActionResult> GetAnimales()
        {
            IEnumerable<ShowAnimalDTO> animales = await _animalRepository.GetAllAnimales();
            return Ok(animales);
        }

        // POST /api/animales
        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] AnimalDTO animalDto)
        {
            try
            {
                Animal animal = this.CreateDtoToAnimal(animalDto);
                await _animalRepository.Create(animal);

                return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, await _animalRepository.GetAnimal(animal.Id));
            }
            catch(Exception ex)
            {
                if(ex is AnimalException)
                    return BadRequest(ex.Message);

                return StatusCode(500, "Ocurrió un error al crear el animal.");
            }
        }

        // PUT /api/animales/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAnimal([FromRoute] int id, [FromBody] AnimalDTO animalDto)
        {
            try
            {
                Animal? animalToUpdate = await _animalRepository.GetById(id);
                
                if (animalToUpdate is null)
                  return NotFound();

                await _animalRepository.Update(this.EditDtoToAnimal(id, animalDto, animalToUpdate));
                return NoContent();
            }
            catch(Exception ex)
            {
                if(ex is AnimalException)
                    return BadRequest(ex.Message);

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE /api/animales/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            try
            {
                if (await _animalRepository.GetById(id) is null)
                    return NotFound();

                await _animalRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Se produjo un error al eliminar el animal.");
            }
        }

        // GET /api/animales/razas
        [HttpGet]
        [Route("razas")]
        public async Task<IActionResult> GetRazas()
        {
            IEnumerable<Raza> razas = await _animalRepository.GetAllRazas();
            return Ok(razas);
        }

        // GET /api/animales/buscar?color={color}&especie={especie}
        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> Search(string? color, string? especie)
        {
            IEnumerable<ShowAnimalDTO> animales = await _animalRepository.SearchAnimalesBy(color, especie);
            return Ok(animales);
        }

        private Animal CreateDtoToAnimal(AnimalDTO animalDto)
        {
            return new Animal
            {
                Nombre = animalDto.Nombre,
                Genero = char.ToUpper(animalDto.Genero),
                Peso = animalDto.Peso,
                Altura = animalDto.Altura,
                Descripcion = animalDto.Descripcion,
                Color = animalDto.Color,
                Edad = animalDto.Edad,
                Especie = animalDto.Especie,
                FechaDeIngreso = animalDto.FechaDeIngreso,
                Id_Raza = animalDto.Id_Raza,
                Id_Refugio = animalDto.Id_Refugio
            };
        }

        private Animal EditDtoToAnimal(int id, AnimalDTO animalDto, Animal animalToUpdate)
        {
            animalToUpdate.Id = id;
            animalToUpdate.Nombre = animalDto.Nombre;
            animalToUpdate.Genero = char.ToUpper(animalDto.Genero);
            animalToUpdate.Peso = animalDto.Peso;
            animalToUpdate.Altura = animalDto.Altura;
            animalToUpdate.Descripcion = animalDto.Descripcion;
            animalToUpdate.Color = animalDto.Color;
            animalToUpdate.Edad = animalDto.Edad;
            animalToUpdate.Especie = animalDto.Especie;
            animalToUpdate.FechaDeIngreso = animalDto.FechaDeIngreso;
            animalToUpdate.Id_Raza = animalDto.Id_Raza;
            animalToUpdate.Id_Refugio = animalDto.Id_Refugio;

            return animalToUpdate;
        }
    }
}

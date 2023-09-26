﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        [Route("animales")]
        public async Task<IActionResult> ListarAnimales()
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
        [Route("animales")]
        public async Task<IActionResult> Create([FromBody] AnimalDTO animalDto)
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
                    return BadRequest(errorMessage + ex.InnerException.Message);

                return BadRequest(errorMessage + ex.Message);
            }
        }

        private Animal DtoToAnimal(AnimalDTO animalDto)
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
    }
}

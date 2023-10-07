using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Controllers
{
    [Route("api/refugios")]
    [ApiController]
    public class RefugioController : ControllerBase
    {
        private readonly IRefugioRepository _refugioRepository;

        public RefugioController(IRefugioRepository refugioRepository)
        {
            _refugioRepository = refugioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRefugios()
        {
            IEnumerable<Refugio> refugios = await _refugioRepository.GetAll();
            return Ok(refugios);
        }
    }
}

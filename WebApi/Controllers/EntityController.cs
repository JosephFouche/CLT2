using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EntityController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IEntityService _service;

        public EntityController(IEntityRepository entityRepository, IEntityService entityService)
        {
            _entityRepository = entityRepository;
            _service = entityService;

        }
        //controller nueva entidad y sus productos asociados a un cliente
        [HttpPost("Registrar entidad con Customer Id")]
        public async Task<IActionResult> Create([FromBody] AddEntityRequest request)
        {
            // var newCard = await _cardRepository.Add(createNewCardDTO);
            return Ok(await _service.Create(request));
        }

        [HttpGet("Obtener todos las entidades asociadas a un Customer")]
        public async Task<IActionResult> Get([FromBody] GetEntityRequest request)
        {
            return Ok(await _service.Get(request));
        }
    }
}

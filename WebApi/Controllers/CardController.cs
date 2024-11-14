using Core.DTOs;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using FluentValidation;
using Infrastructure.Migrations;
using Core.Interfaces.Services;
using Core.Request;
namespace WebApi.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICardService _service;
        public CardController(ICardRepository cardRepository, ICardService cardService)
        {
            _cardRepository = cardRepository;
            _service = cardService;
            
        }
        [HttpGet("cards{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _cardRepository.Get(id));
        }

        // GET: api/Cards/{id}
        [HttpGet("Customers{id}cards")]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            // Llamar al método del repositorio para obtener la cuenta detallada
            var account = await _cardRepository.GetAll(id);

            // Si no se encuentra la cuenta, devolver un NotFound
            if (account == null)
            {
                return NotFound();
            }

            // Devolver la cuenta encontrada
            return Ok(account);
        }
        // POST api/card
        // POST api/card NUEVA TARJETA DE CREDITO
        [HttpPost("NuevaTarjeta")]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest request)
        {
            // var newCard = await _cardRepository.Add(createNewCardDTO);
            return Ok(await _service.Create(request));
            // Verificar si hubo un error en la creación (esto no debería ser necesario si el repositorio maneja los errores)
            //if (newCard == null)
            //{
            //    return BadRequest("Error en la inserción de la tarjeta");
            //}

            //// Retornar 201 Created con el DTO de respuesta
            //return CreatedAtAction(nameof(Create), new { id = newCard.CardId }, newCard);

        }
        private string MaskCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) return cardNumber;
            return cardNumber.Substring(0, 6) + new string('*', cardNumber.Length - 10) + cardNumber.Substring(cardNumber.Length - 4);
        }


    }
}

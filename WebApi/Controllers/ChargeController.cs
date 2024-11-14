using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ChargeController : BaseApiController
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ICardService _service;
        public ChargeController(IChargeRepository chargeRepository, ICardRepository cardRepository, ICardService service)
        {
            _chargeRepository = chargeRepository;
            _cardRepository = cardRepository;
            _service = service;
        }
        // POST: api/charges/{cardId}
        //[HttpPost("{cardId}/charges")]
        [HttpPost("charge")]
        public async Task<IActionResult> CreateCharge([FromBody] CreateChargeRequest request)
        {
            // Validar que el cardId de la URL coincida con el CardId en el DTO
            //return Ok(await _service.AddChargeToCard(request));
            var result = await _service.CreateCharge(request);

            // Retornar la respuesta adecuada. Puedes ajustar el tipo de respuesta según el resultado.
            return Ok(result);

            // Obtener la tarjeta
            //var card = await _cardRepository.GetByIdAsync(cardId);

            //if (card == null)
            //{
            //    return NotFound(new { message = "La tarjeta con el ID proporcionado no existe." });
            //}

            //// Validar que el monto no exceda el AvailableLimit
            //if (addChargeDTO.Amount > card.AvailableLimit)
            //{
            //    return BadRequest(new { message = "El monto del cargo excede el límite disponible en la tarjeta." });
            //}

            //// Restar el monto del cargo del AvailableLimit de la tarjeta
            //card.AvailableLimit -= addChargeDTO.Amount;

            //// Crear el nuevo cargo como entidad Charge
            //var charge = new AddChargeDTO
            //{
            //    CardId = cardId,
            //    Amount = addChargeDTO.Amount,
            //    Description = addChargeDTO.Description,
            //    Date = addChargeDTO.Date
            //};


            // await _chargeRepository.AddAsync(cardId, charge); 

            //// Actualizar la tarjeta
            //await _cardRepository.UpdateAsync(card);

            //// Crear el DTO de respuesta
            //var response = new
            //{
            //    chargeId = charge.ChargeId,
            //    cardId = cardId,
            //    amount = charge.Amount,
            //    availableLimit = card.AvailableLimit, // Nuevo AvailableLimit
            //    description = charge.Description,
            //    date = charge.Date
            //};

            //// Retornar una respuesta 201 Created con el nuevo cargo y el AvailableLimit actualizado
            //return CreatedAtAction(nameof(AddChargeToCard), new { cardId = charge.CardId, chargeId = charge.ChargeId }, response);
        }


    }
}


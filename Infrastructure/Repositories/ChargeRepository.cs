using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly ApplicationDbContext _context;
        public ChargeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseChargeDTO> AddAsync(int CardId, AddChargeDTO addChargeDTO)
        {
            var card = await _context.Cards.FindAsync(CardId);
            if (card == null)
            {
                throw new KeyNotFoundException("La tarjeta con el ID proporcionado no existe.");
            }

            // 2. Validar si el monto excede el límite disponible de la tarjeta
            if (addChargeDTO.Amount > card.AvailableLimit)
            {
                throw new InvalidOperationException("El monto del cargo excede el límite disponible en la tarjeta.");
            }

            // 3. Restar el monto del cargo del AvailableLimit de la tarjeta
            card.AvailableLimit -= addChargeDTO.Amount;

            // 4. Crear una nueva entidad Charge desde el DTO
            var charge = new Charge
            {
                CardId = CardId,
                Amount = addChargeDTO.Amount,
                Description = addChargeDTO.Description,
                Date = addChargeDTO.Date
            };

            // 5. Agregar el cargo a la base de datos
            _context.Charges.Add(charge);

            // 6. Actualizar la tarjeta (en este caso, solo el AvailableLimit)
            _context.Cards.Update(card);

            // 7. Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            var response = new ResponseChargeDTO
            {
                ChargeId = charge.ChargeId,
                CardId = charge.CardId,
                Amount = charge.Amount,
                AvailableLimit = card.AvailableLimit, // Nuevo AvailableLimit
                Description = charge.Description,
                Date = charge.Date
            };

            return response;
        }

        public async Task<AddChargeDTO> CreateCharge(CreateChargeRequest request)
        {
            var chargeToCreate = request.Adapt<Charge>();

            var card = await _context.Cards.FindAsync(request.CardId);
            //corregir
          
            var chartoCreate = request.Adapt<Charge>();
            // Disminuir el límite disponible
            //card.CreditLimit += request.Amount;
            card.AvailableLimit -= request.Amount;

            _context.Charges.Add(chargeToCreate);

            await _context.SaveChangesAsync();

            return chargeToCreate.Adapt<AddChargeDTO>();
        }

        public async Task<bool> VerifyChargeAmount(int cardId, int amount)
        {
            var card = await _context.Cards.FindAsync(cardId);

            if (card is null)
                throw new Exception("No se encontro la tarjeta con el id provisto");

            return card.AvailableLimit  >= amount;
        }

        public Task<bool> VerifyChargeAmount(int cardId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}








using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repository;
        public CardService(ICardRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateNewCardDTO> Create(CreateCardRequest request)
        {
            return await _repository.Create(request);
        }

        public async Task<AddChargeDTO> CreateCharge(CreateChargeRequest request)
        {
            var isTransactionAllowed = await _repository
                .VerifyChargeAmount(request.CardId, request.Amount);

            if (!isTransactionAllowed)
                throw new Exception("El monto supera el limite");

            return await _repository.CreateCharge(request);
        }
    }
}

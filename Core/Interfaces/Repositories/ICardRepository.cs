using Core.DTOs;
using Core.Entities;
using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Task<GetCardDTO> Get(int id);
        Task<List<DetailedCardDTO>> GetAll(int CustomerId);
        Task<CardResponseDTO> Add(CreateNewCardDTO createNewCardDTO);
        Task<Card> GetByIdAsync(int cardId);
        Task UpdateAsync(Card card);
        Task<CreateNewCardDTO> Create(CreateCardRequest request);
        Task<AddChargeDTO> CreateCharge(CreateChargeRequest request);
        Task<bool> VerifyChargeAmount(int cardId, int amount);
    }
}

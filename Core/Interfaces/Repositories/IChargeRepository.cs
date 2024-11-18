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
    public interface IChargeRepository
    {
        // Método para obtener la tarjeta por su ID


        // Otros métodos como agregar, actualizar, eliminar tarjetas, etc.
        Task<ResponseChargeDTO> AddAsync(int CardId, AddChargeDTO addChargeDTO);
        Task<AddChargeDTO> CreateCharge(CreateChargeRequest request);

         Task <bool> VerifyChargeAmount(int cardId, int amount);

    }
}

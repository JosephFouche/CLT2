using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.Interfaces.Services
{
    public interface ICardService
    {
        Task<CreateNewCardDTO> Create(CreateCardRequest request);
        Task<AddChargeDTO> CreateCharge(CreateChargeRequest request);
    }
}

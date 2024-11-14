using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        //Task<PaynmentDTO> AddAsync(int CardId, AddChargeDTO addChargeDTO);
        //task devuelve, (lo que se le mete por parametro)
        Task<ResponsePaymentDTO> AddAsync(int CardId, PaymentDTO paymentDTO);
    }
}

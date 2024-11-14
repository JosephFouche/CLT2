using Core.DTOs;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<ResponsePaymentDTO> AddAsync(int CardId, PaymentDTO paymentDTO)
        {
            throw new NotImplementedException();
        }
    }
}

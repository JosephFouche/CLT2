using Core.DTOs;
using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IEntityService
    {
        Task<ResponseEntityDTO> Create(AddEntityRequest request);
        Task<GetDetailedEntityProductDTO> Get(GetEntityRequest request);

    }
}

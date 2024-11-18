using Core.DTOs;
using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IEntityRepository
    {
        public  Task<ResponseEntityDTO> Create(AddEntityRequest request);
        public Task<List<GetDetailedEntityProductDTO>> Get(GetEntityRequest request);

    }
}

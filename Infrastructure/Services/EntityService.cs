using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        //public Task<ResponseEntityDTO> Add(AddEntityRequest request)
        //{
        //    return await _service.Add(request);
        //}

        //public Task<ResponseEntityDTO> Add(AddEntityDTO addEntityDTO)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ResponseEntityDTO> Create(AddEntityRequest request)
        {
            return await _entityRepository.Create(request);
        }

        public Task<List<GetDetailedEntityProductDTO>> Get(GetEntityRequest request)
        {
            throw new NotImplementedException();
        }

        Task<GetDetailedEntityProductDTO> IEntityService.Get(GetEntityRequest request)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseEntityDTO> Get(GetEntityRequest request)
        //{
        //    return await _entityRepository.Get(request);
        //}

        //public Task<AddEntityDTO> Create(AddEntityRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<GetEntityDTO> Get(GetEntityRequest request)
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task<CreateNewCardDTO> Create(CreateCardRequest request)
        //{
        //    return await _repository.Create(request);
        //}
        //public Task<AddEntityDTO> Create(AddEntityRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<GetEntityDTO> Get(GetEntityRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

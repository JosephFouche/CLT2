using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infrastructure.Contexts;
using Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository

    {
        private readonly ApplicationDbContext _context;
        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //resgitrar una entidad y sus productos asociados a un cliente
        public async Task<ResponseEntityDTO> Create(AddEntityRequest request)
        {

            
            var eEntity = new Entidad
            {
                Name = request.Name,
                CustomerId = request.CustomerID
                // Asignamos el número de tarjeta generado
                // Aquí podrías generar el número de tarjeta si es necesario
                // Este método sería responsable de generar un número único
            };
            _context.Entities.Add(eEntity);

            // 3. Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            var responseEntityDTO = new ResponseEntityDTO
            {
                Name = request.Name,
                CustumerId = request.CustomerID
            };

            // 5. Retornar el DTO con la respuesta
            return responseEntityDTO;
        }

        //public Task<ResponseEntityDTO> Get(GetEntityRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        Task<List<GetDetailedEntityProductDTO>> IEntityRepository.Get(GetEntityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
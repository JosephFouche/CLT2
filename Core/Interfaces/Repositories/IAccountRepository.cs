using Core.DTOs;
using Core.Entities;


namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<DetailedAccountDTO> GetAll(int id);
        
    }
}

using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List();
    CustomerDTO Get(int id);
    Task<List<CustomerDTO>> Add(string firstName, string? lastName);
    Task<List<CustomerDTO>> Update(int id, string name, string name2);
   Task<List<CustomerDTO>> Delete(int id);

}

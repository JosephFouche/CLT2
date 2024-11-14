using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Core.Request;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq;
using Mapster;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDTO> Add(CreateCustomerDTO createCustomerDTO)
    {
        var entity = new Customer
        {
            FirstName = createCustomerDTO.FirstName,
            LastName = createCustomerDTO?.LastName,
            Email = createCustomerDTO.Email,
            Phone = createCustomerDTO?.Phone,
            BirthDate = createCustomerDTO?.BirthDate,


        };

        _context.Customers.Add(entity); //aqui no impactamos aun la BD
        await _context.SaveChangesAsync(); //esto impacta en la BD

        return entity.Adapt<CustomerDTO>();
    }

    public async Task<CustomerDTO> Delete(int id)
    {
        // Buscar el cliente por su ID
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            // Si no se encuentra el cliente, lanzar una excepción
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }

        // Eliminar el cliente de la base de datos
        _context.Customers.Remove(entity);

        // Guardar los cambios en la base de datos
        await _context.SaveChangesAsync();

        // Retornar la lista actualizada de clientes
        return entity.Adapt<CustomerDTO>();  // Usamos await para esperar el resultado asincrónico
    }


    public async Task<CustomerDTO> Get(int Id)
    {
        //buscar el cliente por su Id
        var Entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == Id);

        //si entidad es null
        if (Entity == null)
        {
            //si no se encuentra cliente que envie comentario
            throw new KeyNotFoundException("No se encontro");
            
        }
        return Entity.Adapt<CustomerDTO>();

       
        
    }

    public async Task<List<CustomerDTO>> List()
    {
        var entities = await _context.Customers.ToListAsync();

        return entities.Adapt<List<CustomerDTO>>();

        
    }

    //un método público asíncrono que devuelve una tarea (Task) de tipo List<CustomerDTO>.
    public async Task<List<CustomerDTO>> List(PaginationRequest request)
    {
        //await junto con el método ToListAsync(), que es asíncrono y se
        //ejecuta sobre el contexto de la base de datos (_context.Customers).
        var customer = await _context.Customers
            .Skip((request.Page - 1) * request.Size)//calcula cuántos elementos se deben omitir según la página actual.
            .Take(request.Size)// limita el número de registros que se devuelven en esta consulta
            .Select(customer => new CustomerDTO//Transforma cada objeto Customer en un objeto CustomerDTO
                                               //(que es un tipo de datos más simplificado para ser enviado a la vista o la API
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Phone = customer.Phone,
                Email = customer.Email,
                BirthDate = customer.BirthDate
            }).ToListAsync();//coregido
        return customer.OrderBy(c => c.Id).ToList();//se ordena por Id en orden ascendente
        //Convierte el resultado de la consulta ordenada en una lista de tipo List<CustomerDTO>
    }

    public CustomerDTO AddTo(Customer customer) => new()
    //método público que recibe un objeto de tipo Customer como parámetro y devuelve un nuevo objeto de tipo CustomerDTO
    {

        Id = customer.Id,
        FullName = $"{customer.FirstName}{customer.LastName}",
        Email = customer.Email,
        Phone = customer.Phone,
        BirthDate = customer.BirthDate
    };


    public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
    {
        // Buscar el cliente por su ID
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == updateCustomerDTO.Id);

        if (entity == null)
        {
            // Si no se encuentra el cliente, lanzar una excepción
            throw new KeyNotFoundException($"Customer con ID {updateCustomerDTO} no encontrada.");
        }

        // Actualizar el nombre del cliente
        entity.FirstName = updateCustomerDTO.FirstName;  // FirstName, si no, puedes actualizar otras propiedades
        entity.LastName = updateCustomerDTO.LastName;//modifica lastname
        entity.Email = updateCustomerDTO.Email;  // FirstName, si no, puedes actualizar otras propiedades
        entity.Phone = updateCustomerDTO.Phone;
        entity.BirthDate = updateCustomerDTO.BirthDate;  // FirstName, si no, puedes actualizar otras propiedades


        // Guardar los cambios en la base de datos
        await _context.SaveChangesAsync();

        // Retornar la lista actualizada de clientes
        return entity.Adapt<CustomerDTO>();  // método List() para obtener la lista actualizada de clientes como CustomerDTO
    }

    public Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<DetailedAccountDTO> GetAll(int id)

    {
        throw new NotImplementedException();
    }
}
//agregar y actualizar validar, endpoints
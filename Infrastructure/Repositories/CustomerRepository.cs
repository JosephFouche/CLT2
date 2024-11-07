using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerDTO>> Add(string firstName, string? lastName)
    {
        var entity = new Customer
        {
            FirstName = firstName,
            LastName = lastName
        };

        _context.Customers.Add(entity); //aqui no impactamos aun la BD
        await _context.SaveChangesAsync(); //esto impacta en la BD

        return await List();
    }

    public async Task<List<CustomerDTO>> Delete(int id)
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
        return await List();  // Usamos await para esperar el resultado asincrónico
    }


    public CustomerDTO Get(int Id)
    {
        //buscar el cliente por su Id
        var Entity = _context.Customers.FirstOrDefault(x => x.Id == Id);

        //si entidad es null
        if (Entity == null)
        {
            //si no se encuentra cliente que envie comentario
            throw new KeyNotFoundException("No se encontro");
        }

        var entos = new CustomerDTO
        {
            Id = Entity.Id,
            FullName = $"{Entity.FirstName}{Entity.LastName}"
        };
        return entos;
    }

    public async Task<List<CustomerDTO>> List()
    {
        var entities = await _context.Customers.ToListAsync();

        var dtos = entities.Select(customer => new CustomerDTO
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}"
        });

        return dtos.ToList();
    }

    public async Task<List<CustomerDTO>> Update(int id, string name)
    {
        // Buscar el cliente por su ID
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            // Si no se encuentra el cliente, lanzar una excepción
            throw new KeyNotFoundException($"Customer con ID {id} no encontrada.");
        }

        // Actualizar el nombre del cliente
        entity.FirstName = name;  // FirstName, si no, puedes actualizar otras propiedades
        entity.LastName = name;//modifica lastname

        // Guardar los cambios en la base de datos
        await _context.SaveChangesAsync();

        // Retornar la lista actualizada de clientes
        return await List();  // método List() para obtener la lista actualizada de clientes como CustomerDTO
    }

}
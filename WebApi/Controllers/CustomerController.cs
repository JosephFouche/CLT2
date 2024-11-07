using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        return Ok(await _customerRepository.List());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok(_customerRepository.Get(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] Customer customer)
    {
        return Ok(await _customerRepository.Add(customer.FirstName, customer.LastName));
    }

    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        if (customer == null || customer.Id <= 0)
        {
            return BadRequest("Cliente no válido.");
        }

        try
        {
            // Llama al repositorio para actualizar el cliente y obtener la lista actualizada
            var updatedCustomerList = await _customerRepository.Update(customer.Id, customer.FirstName);

            // Retorna la lista actualizada de clientes en un formato adecuado (200 OK con la lista)
            return Ok(updatedCustomerList);
        }
        catch (KeyNotFoundException ex)
        {
            // Si el cliente no se encuentra, devuelve un error 404 con el mensaje de la excepción
            return NotFound(ex.Message);
        }
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerRepository.Delete(id));
    }
}
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Core.DTOs;
using WebApi.Validations;
using FluentValidation;
using Infrastructure.Repositories;
namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    //validacion
    private readonly IValidator<CreateCustomerDTO> _validateCreate;
    private readonly IValidator<UpdateCustomerDTO> _updateCustomer;

    public CustomerController(ICustomerRepository customerRepository, IValidator<CreateCustomerDTO> validateCreate, IValidator<UpdateCustomerDTO> updateCustomer)
    {
        _customerRepository = customerRepository;
        _validateCreate = validateCreate;
        _updateCustomer = updateCustomer;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request)//From query =  de la consulta en este caso page = 1 size 10
    {
        return Ok(await _customerRepository.List(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _customerRepository.Get(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDTO createCustomerDTO)
    {
        // Validación con FluentValidation
        var validationResult = await _validateCreate.ValidateAsync(createCustomerDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var customerDTO = await _customerRepository.Add(createCustomerDTO);
        return Ok(customerDTO);
        //return Ok(await _customerRepository.Add(createCustomerDTO));
    }


    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO updateCustomerDTO)

    {
        var results = await _updateCustomer.ValidateAsync(updateCustomerDTO);
        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }

        try
        {
            // Llama al repositorio para actualizar el cliente y obtener la lista actualizada
            var updatedCustomer = await _customerRepository.Update(updateCustomerDTO);

            // Retorna la lista actualizada de clientes en un formato adecuado (200 OK con la lista)
            return Ok(updatedCustomer);
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

    // GET: api//{id}
   //* [HttpGet("Account{id}")]
    //public async Task<IActionResult> GetAccount([FromRoute] int id)
    //{
    //    // Llamar al método del repositorio para obtener la cuenta detallada
    //    var account = await _customerRepository.GetAll(id);

    //    // Si no se encuentra la cuenta, devolver un NotFound
    //    if (account == null)
    //    {
    //        return NotFound();
    //    }

    //    // Devolver la cuenta encontrada
    //    return Ok(account);
    //}
    ////
}
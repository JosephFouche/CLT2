using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Request;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
 

namespace WebApi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;


        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            
        }

        // GET: api/Account/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute]int id)
        {
            // Llamar al método del repositorio para obtener la cuenta detallada
            var account = await _accountRepository.GetAll(id);

            // Si no se encuentra la cuenta, devolver un NotFound
            if (account == null)
            {
                return NotFound();
            }

            // Devolver la cuenta encontrada
            return Ok(account);
        }

    }
}

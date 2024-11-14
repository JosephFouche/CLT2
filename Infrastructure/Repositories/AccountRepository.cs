
using Core.DTOs;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DetailedAccountDTO> GetAll(int id)
    {
        var account = await _context.Accounts
            .Include(a => a.Customer)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (account == null)
        {
            throw new Exception("No se encontro la cuenta");
        }

        return account.Adapt<DetailedAccountDTO>();
        //{
        //    Id = account.Id,
        //    Number = account.Number,
        //    Balance = account.Balance,
        //    OpeningDate = account.OpeningDate.ToString("yyyy-MM-dd"),
        //    Customer = new CustomerDTO
        //    {
        //        Id = account.Customer.Id,
        //        FullName = account.Customer.FirstName,
        //        Email = account.Customer.Email,
        //        Phone = account.Customer.Phone,
        //        BirthDate = account.Customer.BirthDate
               
        //    }
        

    }

}
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Core.Interfaces.Repositories;
using Core.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;
/*
{
   public class AccountRepository : IAccountRepository
   {
       private readonly ApplicationDbContext _context;

       public Task<DetailedAccountDTO> GetAll(int id)
       {
           var account = await _context.Accounts
               .Where(a => a.Id == id)
               .Include(a => a.Customer)
               .FirstOrDefaultAsync();

           if (account == null)
           {
               return null;
           }

           return new DetailedAccountDTO
           {
               Id = account.Id,
               Number = account.Number,
               Balance = account.Balance,
               OpeningDate = account.OpeningDate.ToString("yyyy-MM-dd"),
               Customer = new CustomerDTO
               {
                   Id = account.Customer.Id,
                   Name = account.Customer.Name
               }
           }
           }
   }
}*/


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
            return null;
        }

        return new DetailedAccountDTO
        {
            Id = account.Id,
            Number = account.Number,
            Balance = account.Balance,
            OpeningDate = account.OpeningDate.ToString("yyyy-MM-dd"),
            Customer = new CustomerDTO
            {
                Id = account.Customer.Id,
                FullName = account.Customer.FirstName,
                Email = account.Customer.Email,
                Phone = account.Customer.Phone,
                BirthDate = account.Customer.BirthDate
            }
        };
        
    }

}




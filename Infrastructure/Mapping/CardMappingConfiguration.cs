using Core.Entities;
using Core.Request;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;

namespace Infrastructure.Mapping
{
    public class CardMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCardRequest, Card>()
                .Map(dest => dest.CustomerId, src => src.CustomerId) 
            .Map(dest => dest.CardType, src => src.CardType)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDatetime);


            config.NewConfig<Card, CreateNewCardDTO>()
                .Map(dest => dest.CustomerId, src => src.CustomerId) 
                .Map(dest => dest.CardType, src => src.CardType) 
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.InterestRate, src => src.InterestRate);

            config.NewConfig<CreateChargeRequest, Charge>()
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.CardId, src => src.CardId);
            

            config.NewConfig<Charge, AddChargeDTO>()
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Date, src => src.Date.ToShortDateString());
                
        }
    }
}

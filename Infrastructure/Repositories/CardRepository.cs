

using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Core.DTOs;
using Core.Entities;
using Core.Request;

namespace Infrastructure.Repositories

{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Crear una nueva tarjeta de crédito
        public async Task<CardResponseDTO> Add(CreateNewCardDTO createNewCardDTO)
        {
            string generatedCardNumber = GenerateCardNumber();

            // 1.Mapear el DTO a la entidad Card
            var cardEntity = new Card
    {
        CustomerId = createNewCardDTO.CustomerId,
        CardType = createNewCardDTO.CardType,
        CreditLimit = createNewCardDTO.CreditLimit,
        ExpirationDate = createNewCardDTO.ExpirationDate,
        InterestRate = createNewCardDTO.InterestRate,
        CardNumber = generatedCardNumber,
        Status = "active"// Asignamos el número de tarjeta generado
                                                 // Aquí podrías generar el número de tarjeta si es necesario
                                                 // Este método sería responsable de generar un número único
            };

            // 2. Agregar la entidad al contexto de la base de datos
            await _context.Cards.AddAsync(cardEntity);

            // 3. Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // 4. Mapear la entidad Card guardada a un DTO de respuesta (CardResponseDTO)
            var cardResponseDTO = new CardResponseDTO
            {
                CardId = cardEntity.CardId,  // Este es el ID generado automáticamente en la base de datos
                CustomerId = cardEntity.CustomerId,
                CardNumber = MaskCardNumber(cardEntity.CardNumber),  // Se enmascara el número de tarjeta para seguridad
                ExpirationDate = cardEntity.ExpirationDate,  // Devolvemos la fecha tal como está (DateTime?)
                Status = cardEntity.Status  // Supongamos que la tarjeta está activa por defecto
            };

            // 5. Retornar el DTO con la respuesta
            return cardResponseDTO;

        }
        private string GenerateCardNumber()
        {
            // Ejemplo de generación de un número de tarjeta aleatorio de 16 dígitos
            Random rand = new Random();
            string cardNumber = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                cardNumber += rand.Next(0, 10).ToString();  // Genera un número entre 0 y 9
            }
            return cardNumber;
        }

        //ejercicio 2
        public async Task<GetCardDTO> Get(int id)
        {//buscar el cliente por su Id
            var Entity = await _context.Cards.FirstOrDefaultAsync(x => x.CardId == id);

            //si entidad es null
            if (Entity == null)
            {
                //si no se encuentra cliente que envie comentario
                throw new KeyNotFoundException("No se encontro");

            }

            //return Account.Adapt<GetCardDTO>();
            var datos = new GetCardDTO
            {

                CardId = id,
                CustomerId = Entity.CustomerId,
                CardNumber = MaskCardNumber(Entity.CardNumber),
                ExpirationDate = Entity.ExpirationDate,
                Status = Entity.Status,
                CreditLimit = Entity.CreditLimit,
                AvailableLimit = Entity.AvailableLimit,
                InterestRate = Entity.InterestRate,
            };
            return datos;

        }
        //ejercicio 3
        public async Task<List<DetailedCardDTO>> GetAll(int CustomerId)
        {
            var entity = await _context.Cards
       .Where(x => x.CustomerId==CustomerId)  // Assuming 'Customer' is a related entity in the 'Card' table
       .ToListAsync();
            ;
            if (entity == null)
            {
                throw new KeyNotFoundException("No encontrado");
            }
            var datos = entity.Select(x => new DetailedCardDTO
            {
                CardId = x.CardId,  // Ensure this matches the property in your Card entity
                CardNumber = x.CardNumber,  // Ensure 'CardNumber' exists in Card entity
                ExpirationDate = x.ExpirationDate,  // Ensure 'ExpirationDate' exists in Card entity
                CreditLimit = x.CreditLimit,  // Ensure 'CreditLimit' exists in Card entity
                AvailableLimit = x.AvailableLimit  // Ensure 'AvailableLimit' exists in Card entity
            }).ToList();
            return datos;
        }

        

        private string MaskCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length <= 4)
                return cardNumber;
            // Asegurarse de que el número tenga el formato esperado (16 dígitos sin guiones)
            cardNumber = cardNumber.Replace("-", "");
            // Enmascarar los primeros 12 dígitos y dejar los últimos 4 visibles
            var maskedPart = new string('X', 12);  // 'X' para enmascarar
            var visiblePart = cardNumber.Substring(12);  // Últimos 4 dígito
            var visibleDigits = cardNumber.Substring(cardNumber.Length - 4);
            // Formatear con guiones: "XXXX-XXXX-XXXX-1111"
            return $"{maskedPart.Substring(0, 4)}-{maskedPart.Substring(4, 4)}-{maskedPart.Substring(8, 4)}-{visiblePart}";

            
        }

        public async Task<Card> GetByIdAsync(int cardId)
        {
            // Busca la tarjeta por su ID de forma asíncrona
            var card = await _context.Cards
                .Include(c => c.Customer) // Incluye la relación con el Customer si es necesario
                .FirstOrDefaultAsync(c => c.CardId == cardId); // Retorna la primera tarjeta con ese ID o null

            return card; // Retorna la tarjeta encontrada o null si no se encontró
        }

        // Método para agregar una nueva tarjeta
        public async Task<Card> AddAsync(Card card)
        {
            // Agrega la nueva tarjeta al DbContext
            _context.Cards.Add(card);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            return card; // Retorna la tarjeta agregada, ahora con su CardId generado
        }

        // Método para actualizar una tarjeta existente
        public async Task UpdateAsync(Card card)
        {
            // Marca la tarjeta como modificada (no es necesario agregarla al contexto de nuevo)
            _context.Cards.Update(card);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        // Método para eliminar una tarjeta por su ID
        public async Task DeleteAsync(int cardId)
        {
            // Busca la tarjeta en la base de datos
            var card = await _context.Cards.FindAsync(cardId);

            if (card == null)
            {
                throw new KeyNotFoundException("La tarjeta no fue encontrada.");
            }

            // Elimina la tarjeta de la base de datos
            _context.Cards.Remove(card);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
        public async Task<bool> VerifyChargeAmount(int cardId, int amount)
        {
            var card = await _context.Cards.FindAsync(cardId);

            if (card is null)
                throw new Exception("No se encontro la tarjeta con el id provisto");

            return card.CreditLimit - card.AvailableLimit >= amount;
        }

        public async  Task <CreateNewCardDTO> Create(CreateCardRequest request)
        {
            // Adaptar el CreateCardRequest a una nueva instancia de Card
            var cardToCreate = request.Adapt<Card>();
            
            // Asegúrate de no asignar un valor a CardId si es auto-incremental
            //cardToCreate.CardId = 0; // O simplemente no asignarlo si es un campo auto-incremental

            _context.Cards.Add(cardToCreate);
            await _context.SaveChangesAsync();

            //ESTUVO MAL, MALISIIMO POR BRIANvar existingCard = await _context.Cards.FindAsync(cardToCreate.CardId);
            //if (existingCard != null)
            //{
            //    // Manejar el error (ya existe un registro con ese Id)
            //    throw new InvalidOperationException("La tarjeta ya existe.");
            //}

            //// Asegurarse de que Status tenga un valor antes de guardar (puedes asignar un valor predeterminado)
            //if (cardToCreate.Status == null)
            //{
            //    cardToCreate.Status = "Nuevo";  // Asigna un valor predeterminado si es null
            //}

            //// Agregar la tarjeta a la base de datos
            //_context.Cards.Add(cardToCreate);
            //await _context.SaveChangesAsync();jhjvjhv

            // Adaptar la tarjeta creada a un CreateNewCardDTO y devolverlo
            return cardToCreate.Adapt<CreateNewCardDTO>();
        }

        public async Task<AddChargeDTO> CreateCharge(CreateChargeRequest request)
        {
            var chargeToCreate = request.Adapt<Charge>();

            var card = await _context.Cards.FindAsync(request.CardId);
            chargeToCreate.AvailableLimit = card!.AvailableLimit - request.Amount;
            card!.AvailableLimit -= request.Amount;   

            _context.Charges.Add(chargeToCreate);

            await _context.SaveChangesAsync();

            return chargeToCreate.Adapt<AddChargeDTO>();
        }
       
    }
}

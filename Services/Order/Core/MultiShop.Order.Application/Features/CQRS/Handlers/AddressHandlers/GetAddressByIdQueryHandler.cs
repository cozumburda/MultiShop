using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAdressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAdressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail1 = values.Detail1,
                District = values.District,
                UserId = values.UserId,
                Detail2 = values.Detail2,
                Country = values.Country,
                Description = values.Description,
                Email = values.Email,
                Name = values.Name,
                Phone = values.Phone,
                Surname = values.Surname,
                ZipCode = values.ZipCode,
                Isdefault = values.Isdefault,
                IsInvoice=values.IsInvoice
            };
        }
    }
}

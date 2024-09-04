using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail1 = command.Detail1;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            values.Country = command.Country;
            values.Phone = command.Phone;
            values.Surname = command.Surname;
            values.Description = command.Description;
            values.Detail2 = command.Detail2;
            values.Email = command.Email;
            values.Name = command.Name;
            values.ZipCode = command.ZipCode;
            values.Isdefault = command.Isdefault;
            values.IsInvoice = command.IsInvoice;
            await _repository.UpdateAsync(values);
        }
    }
}

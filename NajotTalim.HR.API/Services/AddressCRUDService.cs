using NajotTalim.HR.API.Models;
using NajotTalim.HR.DataAccess;
using NajotTalim.HR.DataAccess.Entities;

namespace NajotTalim.HR.API.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {
        private readonly IAddressRepository _addressRepository;

        public AddressCRUDService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressModel> Create(AddressModel address)
        {
            var newAddress = new DataAccess.Entities.Address
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
            var createdAddress = await _addressRepository.CreateAddress(newAddress);
            var result = new AddressModel
            {
                id = createdAddress.id,
                AddressLine1 = createdAddress.AddressLine1,
                AddressLine2 = createdAddress.AddressLine2,
                City = createdAddress.City,
                PostalCode = createdAddress.PostalCode,
                Country = createdAddress.Country
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.DeleteAddress(id);
        }

        public async Task<AddressModel> Get(int id)
        {
            var address = await _addressRepository.GetAddress(id);
            var addressModel = new AddressModel
            {
                id = address.id,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                PostalCode = address.PostalCode,
                Country = address.Country
            };

            return addressModel;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var result = new List<AddressModel>();
            var addresses = await _addressRepository.GetAddresses();
            foreach (var address in addresses)
            {
                result.Add(new AddressModel
                {
                    id = address.id,
                    AddressLine2 = address.AddressLine2,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Country = address.Country
                });
            }
            return result;
        }

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address
            {
                id = model.id,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country
            };
            var updatedEmployee = await _addressRepository.UpdateAddress(id, address);
            var result = new AddressModel
            {
                id = updatedEmployee.id,
                AddressLine2 = updatedEmployee.AddressLine2,
                City = updatedEmployee.City,
                PostalCode = updatedEmployee.PostalCode,
                Country = updatedEmployee.Country
            };

            return result;
        }
    }
}

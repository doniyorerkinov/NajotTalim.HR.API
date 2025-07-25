﻿using NajotTalim.HR.DataAccess.Entities;


namespace NajotTalim.HR.DataAccess
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);

        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddress(int id);
        Task<Address> UpdateAddress(int id, Address address);
        Task<bool> DeleteAddress(int id);
    }
}

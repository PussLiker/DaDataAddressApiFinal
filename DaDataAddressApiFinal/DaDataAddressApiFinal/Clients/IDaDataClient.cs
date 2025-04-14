using DaDataAddressApiFinal.Models;

namespace DaDataAddressApiFinal.Clients
{
    public interface ICleanAddressClient
    {
        Task<AddressResponse> CleanAddressAsync(string query);
    }
}

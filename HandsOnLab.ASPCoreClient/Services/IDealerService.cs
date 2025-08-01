using HandsOnLab.ASPCoreClient.Models;

namespace HandsOnLab.ASPCoreClient.Services
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetDealersAsync();
        Task<Dealer> GetDealerByIdAsync(int id);
        Task<Dealer> CreateDealerAsync(Dealer dealer);
        Task<Dealer> UpdateDealerAsync(Dealer dealer);
        Task DeleteDealerAsync(int id);
    }
}

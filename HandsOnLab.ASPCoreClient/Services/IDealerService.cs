using HandsOnLab.ASPCoreClient.Models;

namespace HandsOnLab.ASPCoreClient.Services
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetDealersAsync();
        Task<Dealer> GetDealerByIdAsync(int id);
        Task<Dealer> CreateDealerAsync(DealerInsert dealerInsert);
        Task<Dealer> UpdateDealerAsync(DealerUpdate dealerUpdate);
        Task DeleteDealerAsync(int id);
    }
}

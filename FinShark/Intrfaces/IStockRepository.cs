using FinShark.Models;

namespace FinShark.Intrfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStockAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateStockAsync(Stock stock);
        Task<Stock?> UpdateStockAsync(int id,Stock stock);
        Task<Stock?> DeleteStockAsync(int id);
    }
}

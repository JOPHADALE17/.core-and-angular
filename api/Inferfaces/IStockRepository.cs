using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Inferfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock StockModel);
        Task<Stock?> updateAsync(int Id, UpdateStockRequestDTO stockDto);
        Task<Stock?> DeleteAsync(int id);
    }
}
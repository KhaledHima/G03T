using FinShark.Data;
using FinShark.Models;
using FinShark.Models.Dtos;
using FinShark.Models.Dtos.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        //URL/api/stock/GetAllStocks
        [HttpGet("GetAllStocks")]
        public async Task <IActionResult> GetAllStocks()
        {
            //SQL = SELECT * FROM Stocks
            var stocks = await _context.Stocks.ToListAsync();
            //List<StockDto> stockDtos = new List<StockDto>();
            //foreach (var Stock in Stocks)
            //{
            //      s.ToStockDto() = StockMappers.ToStockDto(Stock)
            //    stockDtos.Add(StockMappers.ToStockDto(Stock));
            //}
            return Ok(stocks);
        }
        [HttpGet("GetStockById/{id}")]
        public async Task <IActionResult> GetStockById(int id)
        {
            // SQL = SELECT * FROM Stocks WHERE Id = id 
            //Stock stock = _context.Stocks.Find(id);
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                //return BadRequest("Bad Request");
                //return NoContent();
                return NotFound($"Stock with ID {id} not found");
            }
            return Ok(stock);
        }
        [HttpPost("AddNewStock")]
        public async Task<IActionResult> AddNewStock( Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
        }


        [HttpPost("CreateNewStock")]
        public async Task<IActionResult> CreateNewStock([FromBody] StockRequestDto stockRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //await _context.Stocks.AddAsync(stock);
            //await _context.SaveChangesAsync();
            return Created();
        }


        [HttpPut("UpdateStock/{id}")]
        public async Task <IActionResult> UpdateStock(int id, Stock NewStock)
        {
            //Stock OldStock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            //if (OldStock == null)
            //{
            //    return NotFound($"Stock with ID {id} not found");
            //}
            //OldStock.Symbol = NewStock.Symbol;
            //OldStock.CompanyName = NewStock.CompanyName;
            //OldStock.Purchase = NewStock.Purchase;
            //OldStock.LastDiv = NewStock.LastDiv;
            //OldStock.Industry = NewStock.Industry;
            //OldStock.MarketCap = NewStock.MarketCap;
            //_context.SaveChanges();
            //return Ok(OldStock);
            _context.Stocks.Update(NewStock);
           await _context.SaveChangesAsync();
            return Ok(NewStock);
        }
        [HttpDelete("DeleteStock/{id}")]
        public async Task <IActionResult> DeleteStock(int id)
        {
            Stock stock = await _context.Stocks.FindAsync(id);
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return Ok($"Stock with ID {id} deleted successfully");

            //hard delete
            //var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            //if (stock == null)
            //{
            //    return NotFound($"Stock with ID {id} not found");
            //}
            //_context.Stocks.Remove(stock);
            //_context.SaveChanges();
            //return Ok($"Stock with ID {id} deleted successfully");

            //soft delete with IsDeleted property
            //var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            //if (stock == null)
            //{
            //    return NotFound($"Stock with ID {id} not found");
            //}
            //stock.IsDeleted = true;
            //_context.SaveChanges();
            //return Ok($"Stock with ID {id} marked as deleted successfully");

        }
    }
}

using FinShark.Data;
using FinShark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllStocks()
        {
            //SQL = SELECT * FROM Stocks
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }
        [HttpGet("GetStockById/{id}")]
        public IActionResult GetStockById(int id)
        {
            // SQL = SELECT * FROM Stocks WHERE Id = id 
            //Stock stock = _context.Stocks.Find(id);
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                //return BadRequest("Bad Request");
                //return NoContent();
                return NotFound($"Stock with ID {id} not found");
            }
            return Ok(stock);
        }
        [HttpPost("AddNewStock")]
        public IActionResult AddNewStock( Stock stock)
        {
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
        }
        [HttpPut("UpdateStock/{id}")]
        public IActionResult UpdateStock(int id, Stock NewStock)
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
            _context.SaveChanges();
            return Ok(NewStock);
        }
        [HttpDelete("DeleteStock/{id}")]
        public IActionResult DeleteStock(int id)
        {
            Stock stock = _context.Stocks.Find(id);
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
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

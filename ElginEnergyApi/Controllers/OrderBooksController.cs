using ElginEnergyApi.DatabaseContext;
using ElginEnergyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElginEnergyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBooksController : ControllerBase
    {
        private readonly OrderBooksDbContext _orderBooksDbContext;

        public OrderBooksController(OrderBooksDbContext orderBooksDbContext)
        {
            _orderBooksDbContext = orderBooksDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderBooks>> GetAllOrderBooks()
        {
            return _orderBooksDbContext.Orders.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> AddOrderBooks(OrderBooks orderBooks)
        {
            await _orderBooksDbContext.Orders.AddAsync(orderBooks);
            await _orderBooksDbContext.SaveChangesAsync();

            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> UpdateOrderBook(OrderBooks orderBooks)
        {
            _orderBooksDbContext.Orders.Update(orderBooks);
            await _orderBooksDbContext.SaveChangesAsync();

            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }

        [HttpDelete("{Period:int}")]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> DeleteOrderBook(int Period)
        {
            var orderbook = await _orderBooksDbContext.Orders.FindAsync(Period);

            if (orderbook != null)
            {
                _orderBooksDbContext.Orders.Remove(orderbook);
                await _orderBooksDbContext.SaveChangesAsync();
            }
            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }
    }
}

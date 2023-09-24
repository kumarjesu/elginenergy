using ElginEnergy.Api.DatabaseContext;
using ElginEnergy.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElginEnergy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBooksController : ControllerBase
    {
        private readonly OrderBooksDbContext _orderBooksDbContext;

        public OrderBooks orderBook = new OrderBooks();
        public OrderBooksController(OrderBooksDbContext orderBooksDbContext)
        {
            _orderBooksDbContext = orderBooksDbContext;
        }

        [HttpGet]
        [Route("getobooks")]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> GetAllOrderBooks()
        {
            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }

        [HttpPost]
        [Route("addobooks")]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> AddOrderBooks(OrderBooks orderBooks)
        {
            await _orderBooksDbContext.Orders.AddAsync(orderBooks);
            await _orderBooksDbContext.SaveChangesAsync();
            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }

        [HttpPut]
        [Route("updateobooks")]
        public async Task<ActionResult<IEnumerable<OrderBooks>>> UpdateOrderBook(OrderBooks orderBooks)
        {
            _orderBooksDbContext.Orders.Update(orderBooks);
            await _orderBooksDbContext.SaveChangesAsync();
            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(outputlist);
        }

        [HttpDelete]
        [Route("delobooks/{Period:int}")]
        //public async Task<ActionResult<IEnumerable<OrderBooks>>> DeleteOrderBook(int period)
        public async Task<ActionResult<OrderBooks>> DeleteOrderBook(int period)
        {
            var orderbook = await _orderBooksDbContext.Orders.FindAsync(period);
            if (orderbook != null)
            {
                _orderBooksDbContext.Orders.Remove(orderbook);
                await _orderBooksDbContext.SaveChangesAsync();
            }

            //return RedirectToPage("/getobooks");
            var outputlist = await _orderBooksDbContext.Orders.ToListAsync();
            return Ok(orderbook);
        }
    }
}

using ElginEnergy.DataModels;
using ElginEnergy.UI.Component;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http;
using System.Net.Http.Json;

namespace ElginEnergy.UI.Services
{
    public class OrderBooksService : IOrderBooksService
    {
        public readonly HttpClient _httpClient;
        public readonly OrderBooks orderBook = new OrderBooks();
        public OrderBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task addOrderBooks(OrderBooks orderBook)
        {
            await _httpClient.PostAsJsonAsync<OrderBooks>("api/orderbooks/addobooks", orderBook);
        }

        public async Task deleteOrderBooks(int period)
        {
            await _httpClient.DeleteFromJsonAsync<OrderBooks>("api/orderbooks/delobooks/" + period);
        }

        public async Task<IEnumerable<OrderBooks>> getOrderBooks()
        {
            return await _httpClient.GetFromJsonAsync<OrderBooks[]>("api/orderbooks/getobooks");
        }

        public async Task updateOrderBooks(OrderBooks orderBook)
        {
            await _httpClient.PutAsJsonAsync<OrderBooks>("api/orderbooks/updateobooks", orderBook);
        }
    }
}

using ElginEnergy.DataModels;

namespace ElginEnergy.UI.Services
{
    public interface IOrderBooksService
    {
        Task<IEnumerable<OrderBooks>> getOrderBooks();
        Task addOrderBooks(OrderBooks orderBook);
        Task updateOrderBooks(OrderBooks orderBook);
        Task deleteOrderBooks(int period);
    }
}

using ElginEnergy.DataModels;
using Microsoft.AspNetCore.Components;

namespace ElginEnergy.UI.Component
{
    public partial class UpdateOBooks
    {
        protected IEnumerable<OrderBooks> orderbooks { get; set; } = Enumerable.Empty<OrderBooks>();
        protected OrderBooks orderBook = new OrderBooks();
        protected string Title = "Update";
        [Parameter] public DateTime TradingDay { get; set; }
        [Parameter] public int Period { get; set; }
        [Parameter] public int Quantity { get; set; }
        [Parameter] public decimal Price { get; set; }

        protected async Task UpdateBook()
        {
            await _orderbookService.updateOrderBooks(orderBook);
            NavigateTo();
        }

        public void NavigateTo()
        {
            NavigationManager.NavigateTo("/obdisplay");
        }
    }
}

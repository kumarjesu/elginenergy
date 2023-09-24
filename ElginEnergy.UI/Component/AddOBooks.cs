using ElginEnergy.DataModels;
using Microsoft.AspNetCore.Components;

namespace ElginEnergy.UI.Component
{
    public partial class AddOBooks
    {
        protected IEnumerable<OrderBooks> orderbooks { get; set; } = Enumerable.Empty<OrderBooks>();
        protected OrderBooks orderBook = new OrderBooks();
        protected string Title = "Add";
        [Parameter] public DateTime TradingDay { get; set; }
        [Parameter] public int Period {  get; set; }
        [Parameter] public int Quantity { get; set; }
        [Parameter] public decimal Price { get; set; }

        protected async Task AddBook()
        {
            await _orderbookService.addOrderBooks(orderBook);
            NavigateTo();
        }

        public void NavigateTo()
        {
            NavigationManager.NavigateTo("/obdisplay");
        }

    }
}

using ElginEnergy.DataModels;

namespace ElginEnergy.UI.Pages
{
    public partial class OBDisplay
    {
        protected IEnumerable<OrderBooks> orderbooks { get; set; } = Enumerable.Empty<OrderBooks>();
        protected IEnumerable<OrderBooks> searchLEData { get; set; } = Enumerable.Empty<OrderBooks>();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetOrderBooks();
        }

        protected async Task GetOrderBooks()
        {
            orderbooks = await _orderbookService.getOrderBooks();
        }


        protected void FilterUser()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                orderbooks = searchLEData
                    .Where(x => x.Period.ToString().IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                orderbooks = searchLEData;
            }
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            orderbooks = searchLEData;
        }
    }
}

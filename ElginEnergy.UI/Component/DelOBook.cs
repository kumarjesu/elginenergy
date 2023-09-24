using ElginEnergy.DataModels;
using Microsoft.AspNetCore.Components;

namespace ElginEnergy.UI.Component
{
    public partial class DelOBook
    {
        protected OrderBooks orderBook = new OrderBooks();
        protected void DeleteBook()
        {
            _orderbookService.deleteOrderBooks(Convert.ToInt32(orderBook.Period));
            NavigateTo();
        }

        public void NavigateTo()
        {
            NavigationManager.NavigateTo("/getobooks");
        }
    }
}

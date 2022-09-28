namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> AddItemToBasket(int productId,int quantity);
    }
}

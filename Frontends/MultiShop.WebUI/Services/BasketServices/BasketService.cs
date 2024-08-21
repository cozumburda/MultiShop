using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpPost]
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    if (basketItemDto.Quantity > 0)
                    {
                        if (basketItemDto.Quantity > 20)
                        {
                            basketItemDto.Quantity = 20;
                        }
                        values.BasketItems.Add(basketItemDto);
                    }
                    else
                    {
                        basketItemDto.Quantity = 1;
                        values.BasketItems.Add(basketItemDto);
                    }
                }
                else
                {
                    //values=new BasketTotalDto();
                    if (basketItemDto.Quantity > 0)
                    {
                        if (basketItemDto.Quantity > 20)
                        {
                            basketItemDto.Quantity = 20;
                        }
                        var changeItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                        values.BasketItems.Remove(changeItem);
                        values.BasketItems.Add(basketItemDto);
                    }
                    else
                    {
                        var changeItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                        values.BasketItems.Remove(changeItem);
                    }
                }
            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var reaponseMessage = await _httpClient.GetAsync("Baskets");
            var values = await reaponseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);
        }
    }
}

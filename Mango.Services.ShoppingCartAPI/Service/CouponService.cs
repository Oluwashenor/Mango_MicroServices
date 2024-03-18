using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CouponService(IHttpClientFactory httpClientFactory) : ICouponService
    {
        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}

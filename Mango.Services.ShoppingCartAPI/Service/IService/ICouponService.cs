using Mango.ShoppingCartAPI.Models;

namespace Mango.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
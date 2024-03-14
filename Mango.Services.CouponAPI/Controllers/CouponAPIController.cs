using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = db.Coupons.ToList();
                return objList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon obj = db.Coupons.FirstOrDefault(x=>x.CouponId == id);
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

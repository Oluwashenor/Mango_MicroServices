﻿using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CouponController(ICouponService couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? response = await couponService.GetAllCouponAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }
        [Authorize(Roles = "ADMIN")]

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if ((ModelState.IsValid))
            {
                ResponseDto? response = await couponService.CreateCouponsAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon Created Successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await couponService.GetCouponByIdAsync(couponId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon Created Successfully";
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CouponDelete(CouponDto coupon)
        {
            ResponseDto? response = await couponService.DeleteCouponsAsync(coupon.CouponId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(coupon);
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Egharpay.Business.Interfaces;
using Egharpay.Business.Models;
using Egharpay.Data.Interfaces;
using Egharpay.Entity;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Egharpay.Business.Services
{
    public class CouponCodeBusinessService : ICouponCodeBusinessService
    {
        private readonly ICouponDataService _dataService;

        public CouponCodeBusinessService(ICouponDataService dataService)
        {
            _dataService = dataService;
        }

        public Task<ValidationResult<CouponCode>> Create(CouponCode couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> IsValidCoupon(decimal mobileNumber, string couponCode, bool isLoggedIn = false)
        {
            var validationResult = new ValidationResult();
            try
            {
                var couponResult = await _dataService.RetrieveAsync<CouponCode>(e => e.Code.ToLower() == couponCode.ToLower());
                var data = couponResult.FirstOrDefault();
                if (data?.IsAuthenticationRequired != null && data.IsAuthenticationRequired.Value == isLoggedIn)
                {
                    validationResult.Succeeded = false;
                    validationResult.Message = "Invalid coupon code.Please login";
                    return validationResult;
                }
                var result = await _dataService.RetrieveAsync<MobileCoupon>(e => e.MobileNumber == mobileNumber && e.CouponId == data.CouponCodeId);
                if (!result.Any() && data != null)
                {
                    validationResult.Succeeded = true;
                    validationResult.Message = "Coupon is valid.";
                }
                else
                {
                    validationResult.Succeeded = false;
                    validationResult.Message = "Invalid coupon code or already used.";
                }
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Message = ex.Message;
            }
            return validationResult;
        }
    }
}

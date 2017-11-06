﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egharpay.Business.Extensions;
using Egharpay.Business.Interfaces;
using Egharpay.Business.Models;
using Egharpay.Data.Interfaces;
using Egharpay.Entity;

namespace Egharpay.Business.Services
{
    public class SellerMobileBusinessService : ISellerMobileBusinessService
    {
        private readonly ISellerDataService _dataService;

        public SellerMobileBusinessService(ISellerDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ValidationResult<SellerMobile>> AddMobileInStore(SellerMobile sellerMobile)
        {
            var validationResult = await MobileAlreadyAssign(sellerMobile.MobileId, sellerMobile.SellerId);
            if (!validationResult.Succeeded)
            {
                return validationResult;
            }
            try
            {
                await _dataService.CreateAsync(sellerMobile);
                validationResult.Entity = sellerMobile;
                validationResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                validationResult.Succeeded = false;
                validationResult.Errors = new List<string> { ex.InnerMessage() };
                validationResult.Exception = ex;
            }
            return validationResult;
        }

        private async Task<ValidationResult<SellerMobile>> MobileAlreadyAssign(int mobileId, int sellerId)
        {
            var sellerMobile = await _dataService.RetrieveAsync<SellerMobile>(a => a.MobileId == mobileId && a.SellerId == sellerId);
            var alreadyExists = sellerMobile.Any();
            return new ValidationResult<SellerMobile>
            {
                Succeeded = !alreadyExists,
                Errors = alreadyExists ? new List<string> { "Mobile already exists in store." } : null
            };
        }

    }
}
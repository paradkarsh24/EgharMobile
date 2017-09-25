﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egharpay.Business.Models;
using Egharpay.Entity;
using Egharpay.Entity.Dto;

namespace Egharpay.Business.Interfaces
{
    public interface ISellerBusinessService
    {
        //Create
        Task<ValidationResult<Seller>> CreateSeller(Seller seller);

        //Retrieve
        Task<Seller> RetrieveSeller(int sellerId);
        Task<PagedResult<Seller>> RetrieveSellers(List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<SellerGrid>> Search(string term, List<OrderBy> orderBy = null, Paging paging = null);
    }
}

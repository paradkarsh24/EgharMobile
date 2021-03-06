﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Egharpay.Business.Dto;
using Egharpay.Business.Models;
using Egharpay.Entity;
using Egharpay.Entity.Dto;
using Mobile = Egharpay.Business.Models.Mobile;


namespace Egharpay.Business.Interfaces
{
    public interface IMobileBusinessService
    {
        //Create
        Task<ValidationResult<Mobile>> CreateMobile(Mobile mobile);
        Task<bool> CreateMobile(List<Mobile> mobile);
        Task<bool> CreateBrand(List<Brand> brands);
        Task<bool> CreateMobileImage(List<MobileImage> brands);


        //Retrieve
        Task<Mobile> RetrieveMobile(int mobileId);
        Task<List<MobileImage>> RetrieveMobileGalleryImages(int mobileId);

        Task<PagedResult<Mobile>> RetrieveMobiles(Expression<Func<MobileGrid, bool>> expression, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<Mobile>> RetrieveMobiles(Filter filter, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<Mobile>> Search(string term = null, List<OrderBy> orderBy = null, Paging paging = null);
        Task<PagedResult<MobileGrid>> RetrieveMobilesByBrandId(int brandId, List<OrderBy> orderBy = null, Paging paging = null);
        Task<IEnumerable<Mobile>> RetrieveLatestMobile();
        Task<IEnumerable<MetaSearchKeyword>> RetrieveMetaSearchKeyword();
    }
}

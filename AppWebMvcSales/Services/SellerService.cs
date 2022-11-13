﻿using AppWebMvcSales.Data;
using AppWebMvcSales.Models;

namespace AppWebMvcSales.Services
{
    public class SellerService
    {
        private readonly AppWebMvcSalesContext _contax;
        public SellerService(AppWebMvcSalesContext contax)
        {
            _contax = contax;
        }

        public List<Seller> FindAllSellres()
        {
            return _contax.Seller.ToList();
        }

    }
}

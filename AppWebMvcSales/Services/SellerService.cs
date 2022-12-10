using AppWebMvcSales.Data;
using AppWebMvcSales.Models;
using Microsoft.EntityFrameworkCore;

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
        public Seller? FindById(int id)
        {
            return _contax.Seller.Include(j => j.Departament).FirstOrDefault(j => j.Id.Equals(id));
        }
        public void Insert(Seller obj)
        {
            _contax.Seller.Add(obj);
            _contax.SaveChanges();
        }
        public void Remove(int id)
        {
            var obj = _contax.Seller.Find(id);
            if (obj is not null)
            {
                _contax.Seller.Remove(obj);
                _contax.SaveChanges();
            }
            
        }
        

    }
}

using System.Collections.Generic;

namespace AppWebMvcSales.Models
{
    public class Departament
    {
        public int id { get; set; }
        public string? name { get; set; }
        public ICollection<Seller> Sellers{ get; set; } = new List<Seller>();

        public Departament()
        {

        }
        public Departament(int id, string? name)
        {
            this.id = id;
            name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public decimal TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sellers.Sum(seller => seller.TotalSales(initialDate, finalDate));
        }
    }
}

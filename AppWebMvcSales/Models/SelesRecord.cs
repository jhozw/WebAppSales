using AppWebMvcSales.Models.Enums;

namespace AppWebMvcSales.Models
{
    public class SelesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public SalesStatus Status{ get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }

        public SelesRecord()
        {

        }
        public SelesRecord( DateTime date, decimal amount, SalesStatus status, int sellerId)
        {
            Date = date;
            Amount = amount;
            Status = status;
            SellerId = sellerId;
        }
        public SelesRecord(int id, DateTime date, decimal amount, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

    }
}

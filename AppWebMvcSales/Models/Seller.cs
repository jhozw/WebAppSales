namespace AppWebMvcSales.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal BaseSalary { get; set; }
        public Departament? Departament { get; set; }
        public ICollection<SelesRecord> Selles { get; set; } = new List<SelesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string? nome, string? email, DateTime birthDate, decimal baseSalary, Departament? departament)
        {
            Id = id;
            Nome = nome;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
           
        }

        public void AddSales(SelesRecord sr)
        {
            Selles.Add(sr);

        }
        public void RemoveSales(SelesRecord sr)
        {
            Selles.Remove(sr);
        }
        public decimal TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Selles.Where(j => j.Date >= initialDate && j.Date <= finalDate).Sum(j => j.Amount);
        }
    }
}

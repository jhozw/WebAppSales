using AppWebMvcSales.Data;
using AppWebMvcSales.Models;
    namespace AppWebMvcSales.Services
{
    public class DepartamentService
    {
        private readonly AppWebMvcSalesContext _context;
        public DepartamentService(AppWebMvcSalesContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(j => j.name).ToList();
        }
    }
}

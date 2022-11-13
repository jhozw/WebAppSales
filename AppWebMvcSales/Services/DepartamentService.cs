using AppWebMvcSales.Data;
namespace AppWebMvcSales.Services
{
    public class DepartamentService
    {
        private readonly AppWebMvcSalesContext _context;
        public DepartamentService(AppWebMvcSalesContext context)
        {
            _context = context;
        }
    }
}

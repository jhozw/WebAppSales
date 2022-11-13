using AppWebMvcSales.Data;
namespace AppWebMvcSales.Services
{
    public class SelesRecordService
    {
        private readonly AppWebMvcSalesContext _context;
        public SelesRecordService(AppWebMvcSalesContext context)
        {
            _context = context;
        }
    }
}

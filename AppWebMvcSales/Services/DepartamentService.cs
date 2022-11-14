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
        public Departament? FindById(int id)
        {
            return _context.Departament.Where(j => j.id.Equals(id)).FirstOrDefault();
        }
        public bool Incert(Departament departament)
        {
            if(departament is not null)
            {
                try
                {
                    _context.Departament.Add(departament);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;

        }
        public bool Update(Departament departament)
        {
            if (departament is not null)
            {
                try
                {
                    _context.Departament.Update(departament);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        public bool RemoveItem(int id)
        {
            try
            {
                var departament = FindById(id);
                if (departament is not null)
                {
                    _context.Departament.Remove(departament);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}

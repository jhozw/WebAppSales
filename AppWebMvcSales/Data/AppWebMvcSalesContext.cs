using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppWebMvcSales.Models;

namespace AppWebMvcSales.Data
{
    public class AppWebMvcSalesContext : DbContext
    {
        public AppWebMvcSalesContext (DbContextOptions<AppWebMvcSalesContext> options)
            : base(options)
        {
        }

        public DbSet<AppWebMvcSales.Models.Departament> Departament { get; set; } = default!;
    }
}

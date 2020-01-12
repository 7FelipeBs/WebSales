using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Services
{
    public class DepartmentService
    {
        private readonly WebSalesContext _webSalesContext;

        public DepartmentService(WebSalesContext webSalesContext)
        {
            _webSalesContext = webSalesContext;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _webSalesContext.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}

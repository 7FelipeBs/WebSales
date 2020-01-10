using WebSales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSales.Models;
using Microsoft.EntityFrameworkCore;

namespace WebSales.Services
{
    public class SellerService
    {
        private readonly WebSalesContext _Context;

        public SellerService(WebSalesContext context)
        {
            _Context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _Context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _Context.Add(obj);
            await _Context.SaveChangesAsync();
        }
    }
}

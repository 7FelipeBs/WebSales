using WebSales.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSales.Models;
using WebSales.Services.Exceptions;
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

        public async Task<Seller> FinByIdAsync(int? id)
        {
            return await _Context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = _Context.Seller.Find(id);
            _Context.Remove(obj);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (!_Context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _Context.Update(obj);
                await _Context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

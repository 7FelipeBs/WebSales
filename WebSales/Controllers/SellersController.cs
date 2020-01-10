using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSales.Services;
using WebSales.Models;
using WebSales.Data;

namespace WebSales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly WebSalesContext _webSalesContext;

        public SellersController(SellerService sellerService, WebSalesContext webSalesContext)
        {
            _sellerService = sellerService;
            _webSalesContext = webSalesContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _sellerService.FindAllAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
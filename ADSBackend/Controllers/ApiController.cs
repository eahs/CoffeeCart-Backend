using ADSBackend.Data;
using ADSBackend.Models.ApiModels;
using ADSBackend.Models.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSBackend.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly Services.Configuration Configuration;
        private readonly Services.Cache _cache;
        private readonly ApplicationDbContext _context;

        public ApiController(Services.Configuration configuration, Services.Cache cache, ApplicationDbContext context)
        {
            Configuration = configuration;
            _cache = cache;
            _context = context;
        }

        // GET: api/Config
        [HttpGet("Config")]
        public ConfigResponse GetConfig()
        {
            // TODO: extend this object to include some configuration items
            return new ConfigResponse();
        }

        //GET: models/OrderViewModels/ProductModels
        [HttpGet("GetProductList")]
        public async Task<List<ProductModel>> GetProductList() {
            var ProductModels = await _context.ProductModel.ToListAsync();
            return ProductModels;
        }

        //GET: models/OrderViewModels/OrderModels
        [HttpGet("GetOrderList")]
        public async Task<List<OrderModel>> GetOrderList()
        {
            var OrderModels = await _context.OrderModel.ToListAsync();
            return OrderModels;
        }

        //GET: models/OrderViewModels/ProductOrderModels
        /*[HttpGet("GetProductOrderList")]
        public async Task<List<ProductOrderModel>> GetProductOrderList()
        {
            var ProductOrderModels = await _context.ProductOrderModel.ToListAsync();
            return ProductOrderModels;
        }*/

    }
}
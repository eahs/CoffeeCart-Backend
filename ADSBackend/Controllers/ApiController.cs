using ADSBackend.Data;
using ADSBackend.Models.ApiModels;
using ADSBackend.Models.OrderViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
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

        //POST:
        /*[HttpPost("ChangeOrderStatus")]
        public async Task<OrderModel> AddOrder(int Id, string newStatus)
        {

        }*/

        // GET: api/Config
        [HttpGet("Config")]
        public ConfigResponse GetConfig()
        {
            // TODO: extend this object to include some configuration items
            return new ConfigResponse();
        }

        //GET: api/GetProducts
        [HttpGet("GetProducts")]
        public async Task<List<ProductModel>> GetProductList() {
            var ProductModels = await _context.ProductModel.ToListAsync();
            return ProductModels;
        }

        //GET: api/GetProduct/id
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var ProductModel = await _context.ProductModel.FindAsync(id);

            if (ProductModel == null)
            {
                return NotFound();
            }

            return ProductModel;
        }

        //GET: api/GetOrders
        [HttpGet("GetOrders")]
        public async Task<List<OrderModel>> GetOrders()
        {
            var OrderModels = await _context.OrderModel.ToListAsync();
            return OrderModels;
        }

        //GET: api/GetOrder/id
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderById(int id)
        {
            var OrderModel = await _context.OrderModel.FindAsync(id);

            if (OrderModel == null)
            {
                return NotFound();
            }

            return OrderModel;
        }

        //PUT: api/ProductModel/id
        [HttpPost("ProductModel")]
        public async Task<IActionResult> PutTodoItem(IFormCollection forms)
        {
            int id;
            Int32.TryParse(forms["id"], out id);
            var productmodel = await _context.ProductModel.FirstOrDefaultAsync(p => p.Id == id);

            productmodel.Name = forms["name"];
            productmodel.Description = forms["price"];
            productmodel.Type = ToProductType(forms["type"]);
            productmodel.Price = forms["price"];

            _context.ProductModel.Update(productmodel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.ProductModel.FirstOrDefaultAsync(p => p.Id == forms["id"]) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //to convert string to ProductType
        private ProductType ToProductType(StringValues str)
        {
            if (str == "Beverage")
            {
                return ProductType.Beverage;
            }
            else
            {
                return ProductType.Pastry;
            }
        }
    }
}
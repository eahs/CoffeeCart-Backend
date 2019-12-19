using ADSBackend.Data;
using ADSBackend.Models.ApiModels;
using ADSBackend.Models.OrderModels;
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
        public async Task<Order> AddOrder(int Id, string newStatus)
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
        public async Task<List<Product>> GetProductList() {
            var Products = await _context.Product.ToListAsync();
            return Products;
        }

        //GET: api/GetProduct/id
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var Product = await _context.Product.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }

        //GET: api/GetOrders
        [HttpGet("GetOrders")]
        public async Task<List<Order>> GetOrders()
        {
            var Orders = await _context.Order.ToListAsync();
            return Orders;
        }

        //GET: api/GetOrder/id
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var Order = await _context.Order.FindAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        //GET: api/GetOrderByName/name
        [HttpGet("GetOrderByName/{name}")]
        public async Task<ActionResult<Order>> GetOrderByName(string name)
        {
            var Order = await _context.Order.FirstAsync(p => p.OrdererName == name);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        //PUT: api/Product/id
        [HttpPost("Product")]
        public async Task<IActionResult> EditProduct(IFormCollection forms)
        {
            Int32.TryParse(forms["id"], out int id);
            var Product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);

            Product.Name = forms["name"];
            Product.Description = forms["price"];
            Product.Type = ToProductType(forms["type"]);
            Product.Price = forms["price"];

            _context.Product.Update(Product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Product.FirstOrDefaultAsync(p => p.Id == forms["id"]) == null)
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

        [HttpPost("Order")]
        public async Task<IActionResult> EditOrder(IFormCollection forms)
        {
            Int32.TryParse(forms["id"], out int id);
            var Order = await _context.Order.FirstOrDefaultAsync(p => p.Id == id);

            Order.OrdererName = forms["name"];
            //Order.RoomNumber = forms["room"];
            Order.DateOrdered = Convert.ToDateTime(forms["date"]);
            Order.Status = forms["status"];
            //Order.ProductsOrdered = forms["order"];

            _context.Order.Update(Order);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Product.FirstOrDefaultAsync(p => p.Id == forms["id"]) == null)
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
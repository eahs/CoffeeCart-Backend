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

        // GET: api/News
        [HttpGet("News")]
        public async Task<List<NewsFeedItem>> GetNewsFeed()
        {
            var newsUrl = new Uri("https://www.eastonsd.org/apps/news/news_rss.jsp");

            string sourceUrl = newsUrl.GetLeftPart(UriPartial.Authority);
            string endpoint = newsUrl.PathAndQuery;

            Task<List<NewsFeedItem>> fetchNewsFromSource() => Util.RSS.GetNewsFeed(sourceUrl, endpoint);

            var feedItems = await _cache.GetAsync("RSS", fetchNewsFromSource, TimeSpan.FromMinutes(5));
            return feedItems.OrderByDescending(x => x.PublishDate).ToList();
        }

        // GET: api/Config
        [HttpGet("Config")]
        public ConfigResponse GetConfig()
        {
            // TODO: extend this object to include some configuration items
            return new ConfigResponse();
        }

        [HttpGet("ProductModel")]
        public async Task<List<ProductModel>> GetProductList() {
            var ProductModel = await _context.ProductModel.ToListAsync();
            return ProductModel;
        }
    }
}
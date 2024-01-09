using EcommerceBackEnd.Data;
using EcommerceBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Diagnostics;

namespace EcommerceBackEnd.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext dbContext;
        private readonly IWebHostEnvironment env;

        public ProductsController(EcommerceDbContext dbContext, IWebHostEnvironment env) {
            this.dbContext = dbContext;
            this.env = env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return dbContext.Products.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }


        [Authorize]
        [HttpPost]
        public ActionResult<Product> CreateProduct([FromForm]ProductCreateRequest model)
        {
            string fileName = $"{model.Name.ToLower().Replace(" ", "-")}.jpg";
            string filePath = Path.Combine(env.WebRootPath, "images\\products", $"{model.Name.ToLower().Replace(" ", "-")}.jpg");
            using(var fs = new FileStream(filePath, FileMode.Create))
            {
                model.Image.CopyTo(fs);
            }

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Qty = model.Qty,
                Price = model.Price,
                IsActive = model.IsActive,
                ImageUrl = fileName
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromForm] ProductCreateRequest model)
        {
            string fileName = $"{model.Name.ToLower().Replace(" ", "-")}.jpg";
            string filePath = Path.Combine(env.WebRootPath, "images\\products", $"{model.Name.ToLower().Replace(" ", "-")}.jpg");
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                model.Image.CopyTo(fs);
            }

            var product = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Qty = model.Qty,
                Price = model.Price,
                IsActive = model.IsActive,
                ImageUrl = fileName
            };

            dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return product;
        }
    }
}

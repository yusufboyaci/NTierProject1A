using Microsoft.AspNetCore.Mvc;
using NTierProject1A.DATAACCESS.Context;
using NTierProject1A.DATAACCESS.Repositories.Concrete;
using NTierProject1A.ENTITIES.Entities;

namespace NTierProject1A.UI.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        ProductRepository _productRepository;
        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                List<Product> products = _productRepository.GetActives();
                return Ok(products);
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");    
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_productRepository.GetById(id));
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product) 
        {
            try
            {
                _productRepository.Add(product);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            try
            {
                _productRepository.Update(product);
                _productRepository.Activate(product.Id);
                return NoContent();
            }
            catch 
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Product product)
        {
            try
            {
                _productRepository.Remove(product);
                return NoContent();
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

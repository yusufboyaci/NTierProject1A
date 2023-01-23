using Microsoft.AspNetCore.Mvc;
using NTierProject1A.DATAACCESS.Context;
using NTierProject1A.DATAACCESS.Repositories.Concrete;
using NTierProject1A.ENTITIES.Entities;

namespace NTierProject1A.UI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController(AppDbContext context)
        {
            _categoryRepository = new CategoryRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                List<Category> categories = _categoryRepository.GetActives();
                return Ok(categories);
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
                return Ok(_categoryRepository.GetById(id));
            }
            catch
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                return NoContent();
            }
            catch 
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Category category)
        {
            try
            {
                _categoryRepository.Update(category);
                _categoryRepository.Activate(category.Id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Beklenmedik bir hata oluştu");
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Category category)
        {
            try
            {
                _categoryRepository.Remove(category);
                return NoContent();
            }
            catch (Exception)
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

using Microsoft.AspNetCore.Mvc;
using NTierProject1A.DATAACCESS.Context;
using NTierProject1A.DATAACCESS.Repositories.Concrete;

namespace NTierProject1A.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController(AppDbContext context)
        {
            _categoryRepository = new CategoryRepository(context);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using MellysUndergroundCuisine.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MellysUndergroundCuisine.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public AdminController(AppDbContext Db, IMapper mapper)
        {
            _db = Db;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var allDishes = _db._dishes.ToList();
            List<DishVM> dishVM = _mapper.Map<List<DishVM>>(allDishes);
            return View(dishVM);
        }
        public IActionResult SidePanel()
        {
            return View();
        }

        public IActionResult AddDish()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDish(DishVM dish)
        {
            if (!ModelState.IsValid)
            {
                return View(dish);
            }

            var basePath = AppContext.BaseDirectory;
            Console.Write(basePath+" ********************************************************");
            //var imagePath = Path.Combine(basePath, "", "\NextFolder", "filename.ext");

            //using (var filestream = new FileStream(imagePath, FileMode.Create))
            //{
            //    img.ImgFile.CopyTo(filestream);
            //};
            var newDish = _mapper.Map<Dish>(dish);
            
            await _db._dishes.AddAsync(newDish);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
        }


        public IActionResult EditDish()
        {
            return View();
        }
    }
}

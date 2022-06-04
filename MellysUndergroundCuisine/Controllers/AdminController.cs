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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(AppDbContext Db,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _db = Db;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var allDishes = _db._dishes.ToList();
            List<DishVM> dishVM;
            if (allDishes != null)
            {
                dishVM = _mapper.Map<List<DishVM>>(allDishes);
            }
            else
            {
                dishVM = new List<DishVM>();
            }
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

        [AllowAnonymous]
        public IActionResult PillSpan()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDish(DishVM dish)
        {
            Console.WriteLine("Inside Post AddDish");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("failed Model State");
                return View(dish);
            }

            if (dish.FoodImage.ContentType != "image/jpeg" && dish.FoodImage.ContentType != "image/png" && dish.FoodImage.ContentType != "image/svg+xml")
            {                
                ModelState.AddModelError("File Type Error", "You're only allowed png, jpeg, or svg type files");
                return View(dish);
            }
            
            if (dish.FoodImage != null)
            {
                string folder = "images/foodimages/";
                // create the path name
                folder += Guid.NewGuid().ToString() + "_"+ dish.FoodImage.FileName;
                // combine paths to create the path
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                // make it the filepath So i can link to it 
                dish.FilePath = "/" + folder;
                // create the connection
                await dish.FoodImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
               // log it out but I can't see it  anyways

            }

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

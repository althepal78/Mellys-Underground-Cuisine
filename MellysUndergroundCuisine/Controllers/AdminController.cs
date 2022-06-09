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

        [HttpPost]
        public async Task<IActionResult> AddDish(DishVM dishVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ModelFailure", "failed Model State");
                return View(dishVM);
            }


            if (dishVM.FoodImage.ContentType != "image/jpeg" && dishVM.FoodImage.ContentType != "image/png" && dishVM.FoodImage.ContentType != "image/svg+xml")
            {
                ModelState.AddModelError("File Type Error", "You're only allowed png, jpeg, or svg type files");
                return View(dishVM);
            }

            if (dishVM.FoodImage != null)
            {
                //creating string to where the folders of the images will be
                string folder = "images/foodimages/";

                // create the path name
                folder += Guid.NewGuid().ToString() + "_" + dishVM.FoodImage.FileName;

                // combine paths to create the path
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                // make it the filepath So i can link to it 
                dishVM.FilePath = "/" + folder;

                // create the connection
                await dishVM.FoodImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));


            }

            var newDish = _mapper.Map<Dish>(dishVM);

            await _db._dishes.AddAsync(newDish);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult AddIngredient(string id)
        {
            AddIngredientVM vm = new AddIngredientVM
            {
                DishId = Guid.Parse(id)
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> AddIngredient(AddIngredientVM vm)
        {
            Ingredients ingredient = new Ingredients();
            var trimName = vm.Name.Trim();
            var normalizeTrimName = trimName.ToUpper();
            var exists = _db._ingredients.FirstOrDefault(ing => ing.NormalizeName == normalizeTrimName);
            

            //check you model
            if (exists is null)
            {
                ingredient.Name = trimName;
                ingredient.ID = vm.ID;
                ingredient.NormalizeName = normalizeTrimName;

                await _db._ingredients.AddAsync(ingredient);
                await _db.SaveChangesAsync();
            }
            else
            {
                ingredient.ID = exists.ID;
            }

            if (ingredient.ID == Guid.Empty)
            {
                return BadRequest("Unable to save the igredient to the db");
            }

            var inDishIng = _db._dishIngredients.Any(ing => ing.IngredientsId == ingredient.ID);

            if (inDishIng)
            {
                return BadRequest("Already in dish");
            }

            DishIngredient dishIngred = new DishIngredient
            {
                DishId = vm.DishId,
                IngredientsId = ingredient.ID
            };

            await _db._dishIngredients.AddAsync(dishIngred);
            await _db.SaveChangesAsync();

            return Ok(vm);
        }

        public IActionResult EditDish()
        {
            return View();
        }
    }

}

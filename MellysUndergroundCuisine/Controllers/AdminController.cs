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
    public async Task<IActionResult> AddDish(DishVM dish)
    {

      if (!ModelState.IsValid)
      {
        Console.WriteLine("failed Model State");
        return View(dish);
      }

      //Console.WriteLine(dish.Ingredients.Count + " is the count **********************************");


      if (dish.FoodImage.ContentType != "image/jpeg" && dish.FoodImage.ContentType != "image/png" && dish.FoodImage.ContentType != "image/svg+xml")
      {
        ModelState.AddModelError("File Type Error", "You're only allowed png, jpeg, or svg type files");
        return View(dish);
      }

      if (dish.FoodImage != null)
      {
        string folder = "images/foodimages/";
        // create the path name
        folder += Guid.NewGuid().ToString() + "_" + dish.FoodImage.FileName;
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
      //check you model

      Ingredients ingredient = new Ingredients
      {
        Name = vm.Name,
      };

      await _db._ingredients.AddAsync(ingredient);
      await _db.SaveChangesAsync();
      if(ingredient.ID == Guid.Empty)
      {
        return BadRequest("Unable to save the igredient to the db");
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

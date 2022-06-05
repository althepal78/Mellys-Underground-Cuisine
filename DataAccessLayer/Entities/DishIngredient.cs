
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities
{
    [Keyless]
    public class DishIngredient
    {
        public Dish Dish { get; set; }
        public Ingredients Ingredients { get; set; }
        public Guid DishId { get; set; }
        public Guid IngredientsId { get; set; }
    }
}

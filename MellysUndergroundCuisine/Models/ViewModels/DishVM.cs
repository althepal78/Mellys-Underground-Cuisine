using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MellysUndergroundCuisine.Models.ViewModels
{
    public class DishVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [MinLength(45)]
        public string Information { get; set; }

        [Required]
        [StringLength(500)]
        [MinLength(25)]
        public string Ingredients { get; set; }

        
        public string? FilePath { get; set; }

        [NotMapped]
        public IFormFile FoodImage { get; set; }



        // these are to shorten the ingredients and Information and when they get 
        // hovered on we will show full ingredients and informaiton
        [NotMapped]
        public string InformationShort
        {
            get
            {
                return Information.Substring(0, 40);
            }
        }


        [NotMapped]
        public string IngredientsShort
        {
            get
            {
                return Ingredients.Substring(0, 25);
            }
        }
    }
}

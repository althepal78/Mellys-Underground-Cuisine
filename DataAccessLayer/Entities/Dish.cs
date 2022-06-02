using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Authorize]
    public class Dish
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [Required]
        [StringLength(500)]
        [MinLength(25)]
        public string Information { get; set; }

        [Required]
        [StringLength(500)]
        public string Ingredients { get; set; }

        public IFormFile FormFile { get; set; }
    }
}

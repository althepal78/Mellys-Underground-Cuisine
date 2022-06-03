
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
   
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
        [MinLength(25)]
        public string Ingredients { get; set; }

        [Required]
        public string FilePath { get; set; }
    }
}

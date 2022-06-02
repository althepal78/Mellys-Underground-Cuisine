using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Dish> Dishes { get; set; }
    }
}

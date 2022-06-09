namespace DataAccessLayer.Entities
{
    public class Ingredients
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string? NormalizeName { get; set; }

        public ICollection<DishIngredient> DishIngredient { get; set; }
    }
}

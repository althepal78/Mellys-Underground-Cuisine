﻿namespace MellysUndergroundCuisine.Models.ViewModels
{
  public class AddIngredientVM
  { 
    public Guid ID { get; set; }
    public Guid DishId { get; set; }
    public string Name { get; set; }
  }
}
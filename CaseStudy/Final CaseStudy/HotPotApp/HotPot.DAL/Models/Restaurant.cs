﻿public class Restaurant
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
}
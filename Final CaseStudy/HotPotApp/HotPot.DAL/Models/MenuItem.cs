public class MenuItem
{
    public int MenuItemId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string DietaryInfo { get; set; } // Veg, Nonveg
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}

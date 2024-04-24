namespace CarRent.Models.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public CarCategoryDto Category { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int daily_price { get; set; }
    }

    public class CreateCarDto
    {
        public int Category { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int daily_price { get; set; }
    }

    public class CarCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /*public class RentalDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }*/
}

namespace RestaurantApi.Models
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDevilery { get; set; }
        public string Contactemail { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}

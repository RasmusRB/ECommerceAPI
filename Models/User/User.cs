using ECommerceAPI.Models.Products;

namespace ECommerceAPI.Models.User
{
    public class User 
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public Product? Products { get; set; }
        public Address? Addres { get; set; }

        public class Address
        {
            public string? Street { get; set; }
            public string? Addres { get; set; }
            public string? City { get; set; }
            public string? Country { get; set; }
        }
    }
}
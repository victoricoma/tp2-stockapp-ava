using StockApp.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
        public int Stock { get; set; }

        [StringLength(250, ErrorMessage = "Image name cannot exceed 250 characters.")]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public Product()
        {
            Name = string.Empty;
            Description = string.Empty;
            Image = string.Empty;
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            ValidateDomain();
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Update Invalid Id value");
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            ValidateDomain();
        }

        private void ValidateDomain()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(Name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(Description),
                "Invalid description, description is required.");

            DomainExceptionValidation.When(Description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(Price < 0, "Invalid price negative value.");

            DomainExceptionValidation.When(Stock < 0, "Invalid stock negative value.");

            if (!string.IsNullOrEmpty(Image) && Image.Length > 250)
            {
                DomainExceptionValidation.When(true, "Invalid image name, too long, maximum 250 characters.");
            }
        }
    }
}

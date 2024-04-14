using LabWebApp.Views;
using LabWebApp.Models;
namespace LabWebApp.Tests

{
    public class ProductTests
    {
        [Fact]

        public void Product_PropertiesSetCorrectly()

        {

            // Arrange

            var product = new Product

            {

                Id = 1,

                Name = "Test Product",

                Price = 9.99m,

                Description = "Test product description"

            };

            // Act

            // (No action needed for this test.)

            // Assert

            Assert.Equal(1, product.Id);

            Assert.Equal("Test Product", product.Name);

            Assert.Equal(9.99m, product.Price);

            Assert.Equal("Test product description", product.Description);

        }
        [Fact]
        public void Product_ConstructWithDefaultValues()
        {
            // Arrange
            // No need for arranging as we are testing the default constructor

            // Act
            var product = new Product(); // Create a new instance of the Product class using the default constructor

            // Assert
            Assert.Equal(0, product.Id); // Verify that the Id property is set to its default value (0)
            Assert.Null(product.Name); // Verify that the Name property is null by default
            Assert.Equal(0m, product.Price); // Verify that the Price property is set to its default value (0)
            Assert.Null(product.Description); // Verify that the Description property is null by default
        }

    }
}
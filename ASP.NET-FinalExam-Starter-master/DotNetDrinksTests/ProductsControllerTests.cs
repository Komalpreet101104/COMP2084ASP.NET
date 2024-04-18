using System.Threading.Tasks;
using DotNetDrinks.Controllers;
using DotNetDrinks.Data;
using DotNetDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetDrinks.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);

            _context.Products.Add(new Product { Id = 1, Name = "Product 1", Price = 10, Stock = 100 });
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task Edit_Get_ValidId_ReturnsEditView()
        {
            // Arrange
            var controller = new ProductsController(_context);

            // Act
            var result = await controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.AreEqual("Edit", viewResult.ViewName);
        }

        [TestMethod]
        public async Task DeleteConfirmed_ValidId_RemovesProductFromDatabase()
        {
            // Arrange
            var controller = new ProductsController(_context);

            // Act
            await controller.DeleteConfirmed(1);

            // Assert
            var product = await _context.Products.FindAsync(1);
            Assert.IsNull(product);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

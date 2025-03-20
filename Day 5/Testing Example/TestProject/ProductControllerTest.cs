using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_Example;
using Testing_Example.contracts;
using Testing_Example.Controllers;
using Testing_Example.Repositories;

namespace TestProject
{
    internal class ProductControllerTest
    {
        private Mock<IProductRepository> productsRepositoryMock;
        private List<Product> products;
        private ProductsController _controller;

        [SetUp]
        public void Setup()
        {
            productsRepositoryMock = new Mock<IProductRepository>();
            _controller = new ProductsController(productsRepositoryMock.Object);
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Bread", Price = 30, Description = "1" });
            products.Add(new Product { Id = 2, Name = "Milk", Price = 10, Description = "2" });
            products.Add(new Product { Id = 3, Name = "Cream", Price = 20, Description = "3" });
            products.Add(new Product { Id = 4, Name = "Tomato", Price = 40, Description = "4" });
        }



        [Test]
        public async Task testGetByIdProductExists()
        {
            //set
            int itemId = 1;
            productsRepositoryMock.Setup(a => a.GetById(itemId)).ReturnsAsync(products.FirstOrDefault(p => p.Id == itemId));

            // Act
            var result = await _controller.Get(itemId);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(((Product)okResult.Value).Id, Is.EqualTo(itemId));

        }

        [Test]
        public async Task testGet()
        {
            //set
            int itemId = 1;
            productsRepositoryMock.Setup(a => a.GetAll()).ReturnsAsync(products);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(((List<Product>)(okResult.Value)).Count == 4);

        }

        [Test]
        public async Task testGetByIdProductNotExists()
        {
            //set
            int itemId = 1;
            productsRepositoryMock.Setup(a => a.GetById(itemId)).ReturnsAsync(((Product)null));

            // Act
            var result = await _controller.Get(itemId);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
            //var okResult = result as OkObjectResult;
           // Assert.That(((Product)okResult.Value).Id, Is.EqualTo(itemId));

        }

        [Test]
        public async Task testPost()
        {
            //set
            productsRepositoryMock.Setup(a => a.Add(products[1])).ReturnsAsync(products[1]);

            // Act
            var result = await _controller.Post(products[1]);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That((Product)okResult.Value == products[1]);

        }

        [Test]
        public async Task testDelete_deleted()
        {
            int id = 0;
            //set
            var retVal = productsRepositoryMock.Setup(a => a.Delete(id)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.That(result, Is.TypeOf<OkResult>());

        }

        [Test]
        public async Task testDelete_notDeleted()
        {
            int id = 0;
            //set
            var retVal = productsRepositoryMock.Setup(a => a.Delete(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());

        }

    }
}

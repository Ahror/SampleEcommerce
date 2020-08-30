using Cart.Api.Controllers;
using Cart.Api.Models;
using System;
using FluentAssertions;
using Xunit;
using Cart.Api.Abstractions.Repositories;
using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Cart.UnitTests.ControllerTests
{
    public class CartControllerTest : BaseAutoMockedTest<CartController>
    {
        [Fact]
        public void Get_Cart_By_Id_Should_Return_Cart()
        {
            // Given
            var cart = new CustomerCart();
            var id = Guid.NewGuid().ToString();

            GetMock<ICartRepository>().Setup(x => x.GetCartAsync(id)).ReturnsAsync(cart);

            // When
            var result = Controller.GetCartByIdAsync(id);

            // Then
            result.Should().Be(cart);
        }

        [Fact]
        public async Task Put_Invalid_Cart_Should_Be_Called_Never()
        {
            // Act
            var result = await Controller.UpdateCartAsync(null);

            //Assert
            GetMock<ICartRepository>().Verify(repo => repo.UpdateCartAsync(It.IsAny<CustomerCart>()), Times.Never);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_Valid_Cart_Should_Be_Called_Once()
        {
            //Given
            var customerCart = new CustomerCart
            {
                Id = Guid.NewGuid()
            };
            // Act
            var result = await Controller.UpdateCartAsync(customerCart);

            //Assert
            GetMock<ICartRepository>().Verify(repo => repo.UpdateCartAsync(It.IsAny<CustomerCart>()), Times.Once);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Given_Cart_Should_Be_Return_ItSelf()
        {
            var customerCart = new CustomerCart
            {
                Id = Guid.NewGuid()
            };

            var result = await Controller.UpdateCartAsync(customerCart);

            result.Should().Be(customerCart);
        }

        [Fact]
        public async Task Delete_Cart_Should_Return_Bool()
        {
            var customerCart = new CustomerCart
            {
                Id = Guid.NewGuid()
            };

            var result = await Controller.DeleteCartByIdAsync(customerCart.Id);

            result.Should().Be(true);
        }
    }
}

using Cart.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Cart.UnitTests.ControllerTests
{
    public class CartControllerTest : BaseAutoMockedTest<CartController>
    {
        [Fact]
        public void Get_should_return_foods()
        {
            // Given
            var foods = Enumerable.Repeat(new Food(), 5);
            var foodDtos = Enumerable.Repeat(new FoodDto(), 5);

            GetMock<IRepository<Food>>().Setup(x => x.GetAll()).Returns(foods.AsQueryable());
            GetMock<IMapper>().Setup(x => x.Map<IEnumerable<FoodDto>>(It.IsAny<List<Food>>())).Returns(foodDtos);

            // When
            var result = ClassUnderTest.Get(10, 6);

            // Then
            result.Should().Equal(foodDtos);
        }
    }
}

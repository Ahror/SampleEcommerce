using Grpc.Core;
using Cart.Api.Abstractions.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Cart.Api.Models;
using GrpcCart;
using System.Linq;

namespace Cart.Api.Grps
{
    public class CartService : CartGrps.CartGrpsBase
    {
        private readonly ICartRepository _repository;
        private readonly ILogger<CartService> _logger;

        public CartService(ICartRepository repository, ILogger<CartService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [AllowAnonymous]
        public override async Task<CustomerCartResponse> GetCartById(CartRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for cart id {Id}", context.Method, request.Id);

            var data = await _repository.GetCartAsync(request.Id);

            if (data != null)
            {
                context.Status = new Status(StatusCode.OK, $"Cart with id {request.Id} do exist");

                return MapToCustomerCartResponse(data);
            }
            else
            {
                context.Status = new Status(StatusCode.NotFound, $"Cart with id {request.Id} do not exist");
            }

            return new CustomerCartResponse();
        }

        public override async Task<CustomerCartResponse> UpdateCart(CustomerCartRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call CartService.UpdateCartAsync for buyer id {Buyerid}", request.Buyerid);

            var customerCart = MapToCustomerCart(request);

            var response = await _repository.UpdateCartAsync(customerCart);

            if (response != null)
            {
                return MapToCustomerCartResponse(response);
            }

            context.Status = new Status(StatusCode.NotFound, $"Cart with buyer id {request.Buyerid} do not exist");

            return null;
        }

        private CustomerCartResponse MapToCustomerCartResponse(CustomerCart customerCart)
        {
            var response = new CustomerCartResponse
            {
                Buyerid = customerCart.BuyerId
            };

            customerCart.Items.ForEach(item => response.Items.Add(new CartItemResponse
            {
                Id = item.Id,
                Oldunitprice = (double)item.OldUnitPrice,
                Pictureurl = item.PictureUrl,
                Productid = item.ProductId,
                Productname = item.ProductName,
                Quantity = item.Quantity,
                Unitprice = (double)item.UnitPrice
            }));

            return response;
        }

        private CustomerCart MapToCustomerCart(CustomerCartRequest customerCartRequest)
        {
            var response = new CustomerCart
            {
                BuyerId = customerCartRequest.Buyerid
            };

            customerCartRequest.Items.ToList().ForEach(item => response.Items.Add(new CartItem
            {
                Id = item.Id,
                OldUnitPrice = (decimal)item.Oldunitprice,
                PictureUrl = item.Pictureurl,
                ProductId = item.Productid,
                ProductName = item.Productname,
                Quantity = item.Quantity,
                UnitPrice = (decimal)item.Unitprice
            }));

            return response;
        }
    }
}

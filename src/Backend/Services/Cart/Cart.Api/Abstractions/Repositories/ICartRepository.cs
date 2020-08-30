using Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cart.Api.Abstractions.Repositories
{
    public interface ICartRepository
    {
        Task<CustomerCart> GetCartAsync(string customerId);
        IEnumerable<string> GetUsers();
        Task<CustomerCart> UpdateCartAsync(CustomerCart cart);
        Task<bool> DeleteCartAsync(Guid id);
    }
}

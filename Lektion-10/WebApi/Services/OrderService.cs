using AutoMapper;
using WebApi.Models;
using WebApi.Models.Order;
using WebApi.Models.Product;
using WebApi.Models.User;

namespace WebApi.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(List<Product> shoppingcart, User user);
    }

    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _map;

        public OrderService(DatabaseContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public async Task<Order> CreateAsync(List<Product> shoppingcart, User user)
        {
            var orderEntity = new OrderEntity
            {
                CustomerName = $"{user.FirstName} {user.LastName}",
                Address = $"{user.AddressLine}, {user.ZipCode} {user.City}",
            };

            var orderRows = new List<OrderRowEntity>();
            foreach (var item in shoppingcart)
                orderRows.Add(new OrderRowEntity
                {
                    OrderId = orderEntity.Id,
                    ArticleNumber = item.ArticleNumber
                });

            orderEntity.OrderRows = orderRows;

            _db.Orders.Add(orderEntity);
            await _db.SaveChangesAsync();

            return null!;
        }
    }
}

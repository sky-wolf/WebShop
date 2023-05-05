using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Implementation;
using WebShop.Data.Models;

namespace WebShop.Service
{
    public class OrderItemsService : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderItems> GetListByOrder(int id)
        {
            return _context.OrderItems.Where(x => x.OrderId == id).ToList();
        }

        public async Task Insert(OrderItems orderItems, Order order)
        {
            if (orderItems != null)
            {
                if(orderItems.OrderId != null)
                {
                    _context.OrderItems.AddAsync(orderItems);
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var delItem = _context.OrderItems.Where(x => x.OrderId == id);
            if (delItem != null)
            {
                _context.OrderItems.RemoveRange(delItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}

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
    public class OrderService : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var del = _context.OrderDetails.FirstOrDefault(x => x.Id == id);
            if(del != null)
            {
                _context.OrderDetails.Remove(del);
            }
            await _context.SaveChangesAsync();
        }

        public Order GetById(int id)
        {
            return _context.OrderDetails.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetList()
        {
            return _context.OrderDetails.ToList();
        }

        public List<Order> GetOrdersForUser(string id)
        {
            return _context.OrderDetails.Where(x => x.UserId== id).ToList();
        }

        public async Task<Order> Save(Order order)
        {
            if (order.Id != null)
            {
                order.CreateAt = DateTime.Now;
                _context.OrderDetails.Add(order);
            }
            else
            {
                order.ModifiedAt = DateTime.Now;
                _context.OrderDetails.Update(order);
            }
            
            await _context.SaveChangesAsync();
            return order;
        }

    }
}

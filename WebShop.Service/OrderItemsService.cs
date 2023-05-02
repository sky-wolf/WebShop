﻿using System;
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
            if (orderItems != null || order != null)
            {
               _context.OrderItems.Add(orderItems);
            }
            await _context.SaveChangesAsync();
        }
    }
}

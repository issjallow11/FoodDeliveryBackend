using FoodDeliveryBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Data.Services
{
    public class OrderService : IOrderService
    {

        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Orders.SingleOrDefault(t => t.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.SingleOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderBy(c => c.FirstName).ToList();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Persistence.Data;

namespace POS.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly POSDbContext _context;

        public OrderRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync()
        {
            //IEnumerable<OrderEntity> orders = await _context.Orders.Include(o => o.User.Name);


            throw new NotImplementedException();
            //return orders;


        }
    }
}

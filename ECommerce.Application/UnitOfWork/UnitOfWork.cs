using ECommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context ;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("The context has not been initialized.");
            }
            return _context.SaveChangesAsync();
        }
    }
}

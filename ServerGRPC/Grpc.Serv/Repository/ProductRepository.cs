using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainInfo.Entity;
using Microsoft.EntityFrameworkCore;
using ServerInfo.Contexts;
using ServerInfo.Repository.Contracts;

namespace ServerInfo.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> FindAll()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Exists(Product entity)
        {
            var obj = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
            
            return obj != null;
        }

        public async Task<Product> FindById(Guid id)
        { 
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByDescription(string description)
        {
            var obj = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Description == description);
            
            return obj != null;
        }
    }
}
﻿using DeliveryWebApi.Infrastructure.DbContexts;

namespace DeliveryWebApi.Infrastructure.Repositories;

public class ProductRepository : BaseRepository
{
    public ProductRepository(DeliveryDbContext dbContext) : base(dbContext)
    {
    }

    public void AddList(IEnumerable<Product> products)
    {
        _context.Products.AddRange(products);
    }

    public async Task<Product?> GetAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);

        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _context.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
    }

}

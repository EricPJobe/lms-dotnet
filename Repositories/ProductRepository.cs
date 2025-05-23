using lms_server.database;
using lms_server.dto.product;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDBContext _context;

    public ProductRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task<List<Product>> GetAllProductsAsync(QueryObject queryObject)
    {
        return await _context.Product.ToListAsync();
    }

    public async Task<Product?> CreateProductAsync(Product product)
    {
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto product)
    {
        var productFromRepo = await _context.Product.FindAsync(id);
        if (productFromRepo == null)
        {
            return null;
        }

        productFromRepo.Name = product.Name;
        productFromRepo.Description = product.Description;
        productFromRepo.Price = product.Price;

        await _context.SaveChangesAsync();
        return productFromRepo;
    }
}
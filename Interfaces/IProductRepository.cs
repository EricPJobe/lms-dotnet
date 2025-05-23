using lms_server.dto.product;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<List<Product>> GetAllProductsAsync(QueryObject queryObject);
    Task<Product?> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto product);
}
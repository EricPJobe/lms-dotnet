using lms_server.Models;
using lms_server.dto.product;

namespace lms_server.mapper;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product productModel)
    {
        return new ProductDto
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Description = productModel.Description,
            Price = productModel.Price,
            IsActive = productModel.IsActive
        };
    }
    
    public static Product ToProductFromCreateDto(this CreateProductRequestDto productRequest)
    {
        return new Product
        {
            Name = productRequest.Name,
            Description = productRequest.Description,
            Price = productRequest.Price,
            IsActive = productRequest.IsActive
        };
    }  
    public static Product ToProductFromUpdateDto(this UpdateProductRequestDto productRequest, Product productModel)
    {
        productModel.Name = productRequest.Name;
        productModel.Description = productRequest.Description;
        productModel.Price = productRequest.Price;
        productModel.IsActive = productRequest.IsActive;

        return productModel;
    } 
}
using lms_server.database;
using lms_server.mapper;
using lms_server.dto.product;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace lms_server.controllers;

[Route("api/v1/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IProductRepository _productRepository;
    public ProductController(ApplicationDBContext context, IProductRepository productRepository) 
    {
        _productRepository = productRepository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var products = await _productRepository.GetAllProductsAsync(queryObject);
        var productsDto = products.Select(product => product.ToProductDto());
        return Ok(productsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if(product == null)
        {
            return NotFound();
        }
        
        return Ok(product.ToProductDto());
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productRequest)
    {
        var productModel = productRequest.ToProductFromCreateDto();
        await _productRepository.CreateProductAsync(productModel);
        return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto productRequest)
    {
        var productModel = await _productRepository.UpdateProductAsync(id, productRequest);

        if(productModel == null)
        {
            return NotFound();
        }
        
        return Ok(productModel.ToProductDto());
    }
}
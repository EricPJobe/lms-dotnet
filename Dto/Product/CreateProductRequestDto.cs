namespace lms_server.dto.product;

public class CreateProductRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
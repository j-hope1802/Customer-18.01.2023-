namespace Domain.Dto;
public class ProductDto
{
     public ProductDto()
    {

    }
    public ProductDto(int id , string Name,decimal Price)
    {
        Id = id;
        Name = Name;
        Price=Price;

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
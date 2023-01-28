using Domain.Dto;

using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }
    public List<ProductDto> GetProducts()
    {
        return _context.Products.Select(x=>new ProductDto()
        {
            Id=x.Id,
            Name=x.Name,
            Price=x.Price
          
        }).ToList();
    }
    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }
    
    public void AddProducts(AddProductDto product)
    {
      var newProduct=new Product()
      {
        Id=product.Id,
        Name=product.Name,
        Price=product.Price
      };
      _context.Products.Add(newProduct);
      _context.SaveChanges();
    
    }
    public List<ProductDto> GetProductByName(string name)
    {
        return _context.Products.
            Where(x => x.Name.ToLower().Contains(name.ToLower())).
            Select(x => new ProductDto(x.Id, x.Name,x.Price)).ToList();
    }
          public void UpdateProduct(AddProductDto product)
        {
            var find =  _context.Products.Find(product.Id);
             find.Name = product.Name;
            find.Price = product.Price;
             _context.SaveChanges();
}
public bool DeleteProducts(int id)
        {      
        var find =  _context.Products.Find(id);
        _context.Products.Remove(find);
         _context.SaveChangesAsync();
         return true;
        }
}

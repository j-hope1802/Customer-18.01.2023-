using Domain.Dto;

using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }
    
    public List<OrderDto> GetOrders()
    {
        return _context.Orders.Select(x=>new OrderDto()
        {
            Id=x.Id,
            OrderPlaced=x.OrderPlaced,
            CustomerId=x.CustomerId,
            FullName = string.Concat(x.Customer.FirstName, " ", x.Customer.LastName),
            ProductId=x.OrderDetails.ProductId,
            Price=x.OrderDetails.Product.Price
            
            
        }).ToList();
    }
    
    public Order GetOrderByID(int id)
    {
        return _context.Orders.FirstOrDefault(x => x.Id == id);
    }
    
    public void AddOrderDto(AddOrderDto customer)
    {
      var newOrder=new Order()
      {
        Id=customer.Id,
        OrderPlaced=customer.OrderPlaced,
        OrderFulfilled=customer.OrderFulfilled,
        CustomerId=customer.CustomerId,
      };
      _context.Orders.Add(newOrder);
      _context.SaveChanges();
    
    }
    public List<OrderDto> GetOrderByDate(DateTime date)
    {
        return _context.Orders.
            Where(x => x.OrderPlaced==date).
            Select(x => new OrderDto(x.OrderPlaced, x.OrderFulfilled)).ToList();
    }
          public void UpdateOrder(AddOrderDto customer)
        {
            var find =  _context.Orders.Find(customer.Id);
            
             find.OrderFulfilled = customer.OrderFulfilled;
            find.OrderPlaced = customer.OrderPlaced;
             _context.SaveChanges();
}
public bool DeleteOrders(int id)
        {      
        var find =  _context.Orders.Find(id);
        _context.Orders.Remove(find);
         _context.SaveChangesAsync();
         return true;
      
        }
}

using Domain.Dto;

using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }
    
    public List<CustomerDto> GetCustomers()
    {
        return _context.Customers.Select(x=>new CustomerDto()
        {
            Id=x.Id,
            FirstName=x.FirstName,
            LastName=x.LastName,
            Address=x.Address,
            Phone=x.Phone,
            Email=x.Email
        }).ToList();
    }
    
    public Customer GetCustomerById(int id)
    {
        return _context.Customers.FirstOrDefault(x => x.Id == id);
    }
    
    public void AddCustomer(AddCustomerDto customer)
    {
      var newCustomer=new Customer()
      {
        Id=customer.Id,
        FirstName=customer.FirstName,
        LastName=customer.LastName,
        Email=customer.Email,
        Address=customer.Address,
        Phone=customer.Phone
      };
      _context.Customers.Add(newCustomer);
      _context.SaveChanges();
    
    }
    public List<CustomerDto> GetCustomerByName(string name,string lastname )
    {
        return _context.Customers.
            Where(x => x.FirstName.ToLower().Contains(name.ToLower())).

            Select(x => new CustomerDto(x.Id, x.FirstName)).ToList();
            
    }
          public void UpdateCustomer(AddCustomerDto customer)
        {
            var find =  _context.Customers.Find(customer.Id);
            
             find.FirstName = customer.FirstName;
            find.LastName = customer.LastName;
            find.Email = customer.Email;
            find.Address = customer.Address;
            find.Phone = customer.Phone;

             _context.SaveChanges();
}
public bool DeleteCustomers(int id)
        {      
        var find =  _context.Customers.Find(id);
        _context.Customers.Remove(find);
         _context.SaveChangesAsync();
         return true;
      
        }
}

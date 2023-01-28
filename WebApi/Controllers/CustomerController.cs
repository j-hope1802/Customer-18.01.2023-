        using Domain.Dto;
        using Domain.Entity;
        using Infrastructure.Services;
        using Microsoft.AspNetCore.Mvc;

        namespace WebApi.Controllers;

        [ApiController]
        [Route("[controller]")]
        public class CustomerController:ControllerBase
        {
                private readonly CustomerService _customerService;

                public CustomerController(CustomerService customerService)
                {
                        _customerService = customerService;
                }

                [HttpGet]
                public List<CustomerDto> GetCustomers()
                {
                        return _customerService.GetCustomers();
                }
                
                [HttpGet("searchbyname")]
                public List<CustomerDto> GetCustomersByName([FromQuery] string name,string lastname)
                {
                        return _customerService.GetCustomerByName(name,lastname);
                }
                [HttpGet("GetBYID")]
                public Customer GetById(int id){
                return _customerService.GetCustomerById(id);
                }
                
                [HttpPost]
                public bool AddCustomerDto(AddCustomerDto customer)
                {
                        _customerService.AddCustomer(customer);
                        return true;
                }
                [HttpPut]
                public bool UpdateCustomer(AddCustomerDto customer)
                {
                _customerService.UpdateCustomer(customer);
                return true;
                }
                [HttpDelete]
                public bool DeleteCustomers (int id)
                {
                _customerService.DeleteCustomers( id);
                return true;
                } 
        }
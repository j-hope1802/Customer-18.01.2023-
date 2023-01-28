using Domain.Dto;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController:ControllerBase
{
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
                _orderService = orderService;
        }

        [HttpGet]
        public List<OrderDto> GetOrders()
        {
                return _orderService.GetOrders();
        }
        
        
        [HttpPost]
        public bool AddOrderDto(AddOrderDto customer)
        {
                _orderService.AddOrderDto(customer);
                return true;
        }
        [HttpPut]
        public bool UpdateOrder(AddOrderDto customer)
        {
        _orderService.UpdateOrder(customer);
        return true;
        }
        [HttpDelete]
        public bool DeleteOrders(int id)
        {
            _orderService.DeleteOrders( id);
            return true;
        } 
         
       

}
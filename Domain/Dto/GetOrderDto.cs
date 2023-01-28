namespace Domain.Dto;
public class OrderDto{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulfilled { get; set; }
     public int CustomerId { get; set; }
    public string FullName{get;set;}
    public int ProductId {get;set;}
    public decimal Price{get;set;}
    public  OrderDto(DateTime OrderPlaced,DateTime OrderFulfilled){
        this.OrderPlaced = OrderPlaced;
        this.OrderFulfilled = OrderFulfilled;
    }
    public OrderDto(){

    }

}
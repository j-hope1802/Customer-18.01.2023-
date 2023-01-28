namespace Domain.Dto;
public class AddOrderDto{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulfilled { get; set; }
    public int CustomerId { get; set; }
    public int ProductId {get;set;}



}
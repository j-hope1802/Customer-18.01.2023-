namespace Domain.Dto;
public class CustomerDto{ 
    public CustomerDto()
    {

    }
    public CustomerDto(int id , string firstName)
    {
        Id = id;
        FirstName = firstName;
    }
      public int  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
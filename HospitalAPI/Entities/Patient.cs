namespace HospitalAPI.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PIN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
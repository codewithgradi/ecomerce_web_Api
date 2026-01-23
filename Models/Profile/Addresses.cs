public class Addresses
{
  public int Id { get; set; }
  public string? AccountId { get; set; }
  public string? AddressLineOne { get; set; }
  public string? AddressLineTwo { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public int ZipCode { get; set; }
  public string? Country { get; set; }
  public bool IsDefault { get; set; } = false;

  //Navigation Property
  public AppUser? AppUser { get; set; }
}
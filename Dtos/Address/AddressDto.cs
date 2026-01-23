using System.ComponentModel.DataAnnotations;

public class AddressDto
{
  [Required]
  public int Id { get; set; }
  [Required]
  public string? AccountId { get; set; }
  [Required]
  [MinLength(1, ErrorMessage = "First line of address should be at least one character long")]
  public string? AddressLineOne { get; set; }
  [Required]
  [MinLength(1, ErrorMessage = "Second line of address should be at least one character long")]
  public string? AddressLineTwo { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "City should be at least three characters long")]
  public string? City { get; set; }
  [Required]
  [MinLength(3, ErrorMessage = "State should be at least three characters long")]
  public string? State { get; set; }
  [Required]
  [MinLength(4, ErrorMessage = "Zipcode should be at least four characters long")]

  public string? ZipCode { get; set; }
  [Required]
  public string? Country { get; set; }
  [Required]
  public bool IsDefault { get; set; } = false;

  //Navigation Property
  public AppUser? AppUser { get; set; }
}
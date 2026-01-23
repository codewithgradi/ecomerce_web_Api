public static class AccountMappers
{
  public static UserDto ToUserDto(this AppUser user)
  {
    return new UserDto
    {
      FirstName = user.FirstName,
      LastName = user.LastName,
      CreatedAt = user.CreatedAt,
      Email = user.Email,
      Id = user.Id,
      PasswordHash = user.PasswordHash,
      PhoneNumber = user.PhoneNumber
    };
  }
  public static UserDto ToUserDtoFromCreate(this AppUser user)
  {
    return new UserDto
    {
      Id = user.Id,
      CreatedAt = user.CreatedAt,
      Email = user.Email,
      PasswordHash = user.PasswordHash
    };
  }
  public static AddressDto ToAddressDto(this Addresses addresses)
  {
    return new AddressDto
    {
      Id = addresses.Id,
      AccountId = addresses.AccountId,
      AddressLineOne = addresses.AddressLineOne,
      AddressLineTwo = addresses.AddressLineTwo,
      City = addresses.City,
      Country = addresses.Country,
      IsDefault = addresses.IsDefault,
      ZipCode = addresses.ZipCode,
      State = addresses.State
    };
  }
}
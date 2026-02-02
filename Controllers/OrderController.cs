using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
  private readonly IOrderRepo _orderRepo;
  private readonly UserManager<AppUser> _userManager;
  public OrderController(UserManager<AppUser> userManager, IOrderRepo orderRepo)
  {
    _orderRepo = orderRepo;
    _userManager = userManager;
  }
  [HttpGet]
  [Authorize]
  public async Task<IActionResult> GetAll()
  {

  }
  [HttpGet("{id:int}")]
  [Authorize]
  public async Task<IActionResult> GetOne()
  {

  }
  [HttpPost]
  [Authorize]
  public async Task<IActionResult> CreateOne()
  {

  }
  [HttpPut("{id:int}")]
  [Authorize]
  public async Task<IActionResult> ShipOder()
  {

  }
}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebShop.Data.Implementation;
using WebShop.Data.Models;
using WebShop.ViewModels.Order;
using WebShop.ViewModels.User;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _itemsRepository;
        private readonly IProductRepository _productRepository;
        readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderRepository orderRepository, IOrderItemsRepository itemsRepository, IProductRepository productRepository, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _itemsRepository = itemsRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [Route("CheckOut")]
        public async Task<IActionResult> CheckOut(CheckoutViewModel model)
        {

            if (ModelState.IsValid)
            {
                var currentUser = GetCurrentUser();
                var user = await _userManager.FindByIdAsync(currentUser.Id);

                if(user != null)
                {
                    int total = 0;
                    Order order = new Order();
                    order.UserId = user.Id;
                    order.Status = false;
                    order.CreateAt = DateTime.Now;

                    order = await _orderRepository.Save(order);

                    foreach (var item in model.Data)
                    {
                        var product = _productRepository.GetById(Convert.ToInt32(item.Id));
                        OrderItems orderItems = new OrderItems
                        {
                            OrderId = order.Id,
                            ProductId = Convert.ToInt32(item.Id),
                            Quantity = Convert.ToInt32(item.Quantity),
                            CreateAt = order.CreateAt,
                        };
                        _itemsRepository.Insert(orderItems, order);

                        total += product.Prise * Convert.ToInt32(item.Quantity);
                    }

                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize]
        public List<Order> History()
        {
            var currentUser = GetCurrentUser();

            var history = _orderRepository.GetOrdersForUser(currentUser.Id);

            return history;
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Id = userClaims.FirstOrDefault(x => x.Type == "UserId")?.Value,
                    Username = userClaims.FirstOrDefault(x => x.Type == "Username")?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using WebShop.Data.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebShop.Data.Models;
using System.Xml;
using WebShop.Admin.ViewModels.Orders;

namespace WebShop.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderRepository orderRepository, IOrderItemsRepository orderItemsRepository, UserManager<ApplicationUser> userManager, IProductRepository productRepository)
        {
            _orderItemsRepository = orderItemsRepository;
            _orderRepository = orderRepository;
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var order = _orderRepository.GetList();
            return View(order);
        }

        public async Task<IActionResult> Test()
        {
            var rand = new Random();
            //var adminid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var admin = await _userManager.GetUserIdAsync(user);

            Order orderDetails = new Order();
            orderDetails.UserId = Guid.NewGuid().ToString();
            orderDetails.Status = false;
            orderDetails.CreateAt = DateTime.Now;

            await _orderRepository.Save(orderDetails);

            var cart = _productRepository.GetList();

            int total = 0;
            foreach(var item in cart)
            {
                var quan = rand.Next(1, item.Quantity);
                OrderItems orderItems = new OrderItems
                {
                    OrderId = orderDetails.Id,
                    ProductId = item.Id,
                    ProductName = item.Name,
                    APrice = item.Prise,
                    Quantity = quan,
                    CreateAt = orderDetails.CreateAt,
                };
                await _orderItemsRepository.Insert(orderItems, orderDetails);
                total += item.Prise * quan;
            }

            orderDetails.Total = total;
            orderDetails.Payment = "Test";
            await _orderRepository.Save(orderDetails);
            
            return RedirectToAction("Index");
        }

        public IActionResult PickList(int id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            OrderViewModel wm = new OrderViewModel();

            wm.Detail = _orderRepository.GetById(id);

            wm.Items = _orderItemsRepository.GetListByOrder(wm.Detail.Id);

            return View(wm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var del = _orderRepository.GetById(id);
            if (del != null)
            {
                var itemR = _orderItemsRepository.GetListByOrder(del.Id);
                if(itemR.Count > 0)
                {
                    await _orderItemsRepository.Delete(del.Id);
                }

                await _orderRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}

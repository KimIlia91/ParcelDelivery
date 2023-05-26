using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;
using DeliveryParcel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeliveryParcel.Web.Controllers
{
    /// <summary>
    /// Контроллер для обработки запросов на главной странице.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        /// <param name="logger">Интерфейс логгера.</param>
        /// <param name="orderService">Сервис для работы с заказами.</param>
        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orderResponse = await _orderService.GetAllOrdesAsync();
            return View(orderResponse.Result);
        }

        /// <summary>
        /// Обработчик GET-запроса для получения всех заказов в табличку из библиотеки CloudTasbles.
        /// </summary>
        /// <returns>Результат операции в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orderResponse = await _orderService.GetAllOrdesAsync();
            return Json(new { Data = orderResponse.Result });
        }

        /// <summary>z
        /// Обработчик GET-запроса для создания заказа.
        /// </summary>
        /// <returns>Результат операции в виде представления.</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Обработчик POST-запроса для создания заказа.
        /// </summary>
        /// <param name="createVm">Модель создания заказа.</param>
        /// <returns>Результат операции в виде представления.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateVm createVm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createVm);

                var orderResponse = await _orderService.MakeOrderAsync(createVm);
                if (orderResponse.IsSuccess)
                {
                    TempData["success"] = "Заказ успешно создан!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["error"] = "Не удалось добавить заказ!";
                return View(createVm);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка при добавлении заказа.", ex);
                return View(nameof(Error));
            }
        }

        /// <summary>
        /// Обработчик GET-запроса для отображения страницы с конфиденциальностью.
        /// </summary>
        /// <returns>Результат операции в виде представления. Дефолтный метод.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Обработчик GET-запроса для отображения страницы с ошибкой.
        /// </summary>
        /// <returns>Результат операции в виде представления. Дефолтный метод</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
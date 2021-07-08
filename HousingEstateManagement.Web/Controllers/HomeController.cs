using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.PaymentApiModel;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.Services.APIServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly IPaymentAPIService _paymentAPIService;

        public HomeController(IAnnouncementService announcementService, IExpenseService expenseService,
            IUserService userService, IMessageService messageService, IPaymentAPIService paymentAPIService)
        {
            _announcementService = announcementService;
            _expenseService = expenseService;

            _userService = userService;
            _messageService = messageService;
            _paymentAPIService = paymentAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var announcements = await _announcementService.GetAllAsync();
            return View(announcements.Data);
        }

        public async Task<IActionResult> GetUnpaidExpense()
        {
            var user = _userService.GetUserFromSession();
            var expenses = await _expenseService.GetExpensesWithRelations();
            var expensesOfDebt = expenses.Data.Where( x=> x.UserName == user.UserName && !x.IsPaid).ToList();
            return View(expensesOfDebt);
        }

        public async Task<IActionResult> GetPaidExpense()
        {
            var user = _userService.GetUserFromSession();
            var expenses = await _expenseService.GetExpensesWithRelations();
            var expensesOfDebt = expenses.Data.Where(x => x.UserName == user.UserName && x.IsPaid).ToList();
            return View(expensesOfDebt);
        }

        public async Task<IActionResult> Inbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages.Data != null)
            {
                var messageList = allMessages.Data.Where(x => x.ReceiverId == user.Id).ToList();
                List<MessageDto> messageDtos = new List<MessageDto>();
                foreach (var item in messageList)
                {
                    var sender = await _userService.FindById(item.SenderId);
                    var messageDto = new MessageDto
                    {
                        Id = item.Id,
                        SenderId = item.SenderId,
                        ReceiverId = item.ReceiverId,
                        MessageContent = item.MessageContent,
                        UserName = sender.Data.UserName
                    };
                    messageDtos.Add(messageDto);
                }
                return View(messageDtos);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Outbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages.Data != null)
            {
                var messageList = allMessages.Data.Where(x => x.SenderId == user.Id).ToList();
                List<MessageDto> messageDtos = new List<MessageDto>();
                foreach (var item in messageList)
                {
                    var receiver = await _userService.FindById(item.ReceiverId);
                    var messageDto = new MessageDto
                    {
                        Id = item.Id,
                        SenderId = item.SenderId,
                        ReceiverId = item.ReceiverId,
                        MessageContent = item.MessageContent,
                        UserName = receiver.Data.UserName
                    };
                    messageDtos.Add(messageDto);
                }
                return View(messageDtos);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SendMessageToAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToAdmin(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderId = user.Id;
            message.ReceiverId = "a21ccc6c-6a3e-4127-af9c-d537d19eb5cc";
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }

        [HttpGet]
        public async Task<IActionResult> CreatePayment(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            var CreatePayment = new CreatePaymentDto
            {
                ExpenseId = expense.Data.Id,
                FlatId = expense.Data.FlatId,
                InvoiceAmount = expense.Data.Price
            };
            return View(CreatePayment);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var paidExpense = await _expenseService.GetByIdForPayment(createPaymentDto.ExpenseId);
            createPaymentDto.InvoiceAmount = paidExpense.Data.Price;
            createPaymentDto.FlatId = paidExpense.Data.FlatId;
            createPaymentDto.ExpenseId = paidExpense.Data.Id;
            var response = await _paymentAPIService.CreatePayment(createPaymentDto);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                paidExpense.Data.IsPaid = true;
                _expenseService.UpdateForPayment(paidExpense.Data);
                TempData.Add("Messages",response.Message);
                return RedirectToAction("GetPaidExpense");
            }
            TempData.Add("Messages", response.Message);
            return RedirectToAction("GetUnPaidExpense");
        }
    }
}
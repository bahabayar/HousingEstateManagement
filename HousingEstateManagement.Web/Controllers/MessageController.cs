using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var user = _userService.GetUserFromSession();
            var allMessages = await _messageService.GetAllAsync();
            if (allMessages.Data != null)
            {
                var messageList = allMessages.Data.Where(m => m.ReceiverId == user.Id).ToList();
                var inboxList = await _messageService.GetListInbox(messageList);
                return View(inboxList.Data);
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
                var messageList = allMessages.Data.Where(m => m.SenderId == user.Id).ToList();
                var outBoxList = await _messageService.GetListOutbox(messageList);
                return View(outBoxList.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var userList = await _userService.GetAllAsync();
            var messageDto = new MessageDto
            {
                Users = userList.Data
            };
            return View(messageDto);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            var user = _userService.GetUserFromSession();
            message.SenderId = user.Id;
            await _messageService.AddAsync(message);
            return RedirectToAction("OutBox");
        }

        //[HttpGet]
        //public IActionResult DeleteMessageFromInbox(int id)
        //{
        //    _messageService.Remove(id);
        //    return RedirectToAction("Inbox");
        //}

        //[HttpGet]
        //public IActionResult DeleteMessageFromOutbox(int id)
        //{
        //    _messageService.Remove(id);
        //    return RedirectToAction("Outbox");
        //}
    }
}
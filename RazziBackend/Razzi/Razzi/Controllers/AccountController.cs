using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Razzi.Models;
using Razzi.Options;
using Razzi.ViewModels.Account;
using System.IO;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Razzi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private EmailServerOptions _emailServerOptions;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IWebHostEnvironment env, 
            IOptionsMonitor<EmailServerOptions> emailServerOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _emailServerOptions = emailServerOptions.CurrentValue;
            emailServerOptions.OnChange((e) =>
            {
                _emailServerOptions = e;
            });
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser user = await _userManager.FindByEmailAsync(loginVM.Login);

            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginVM.Login);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Login or password is wrong");
                return View();
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Login or password is wrong");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser newUser = new AppUser()
            {
                FullName = registerVM.FullName,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }

            await _signInManager.SignInAsync(newUser, false);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordVM);
            }

            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_emailServerOptions.Name, _emailServerOptions.Email));
            message.To.Add(new MailboxAddress(user.FullName, user.Email));
            message.Subject = "Reset Password";

            string emailBody = string.Empty;

            using(StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "templates", "imported-from-beefreeio.html")))
            {
                emailBody = streamReader.ReadToEnd();
            }

            string forgotPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = Url.Action("changepassword", "account", new { Id = user.Id, token = forgotPasswordToken}, Request.Scheme);

            emailBody = emailBody.Replace("{{url}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.bk.ru", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailServerOptions.Email, _emailServerOptions.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
            
            return RedirectToAction("CheckEmail");
        }

        public IActionResult CheckEmail()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM, string id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user is null)
            { 
                ModelState.AddModelError("", $"User with id {id} was not found");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, changePasswordVM.Token, changePasswordVM.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Could not change user's password");
            }

            return RedirectToAction("Index");
        }
    }
}

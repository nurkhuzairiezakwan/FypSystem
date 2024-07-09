// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using ADStarter.DataAccess.Data;
using ADStarter.Utility;
using ADStrater.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace ADStarterWeb.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDBContext _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDBContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string? Role { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

            [Required(ErrorMessage = "The IC number is required.")]
            [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid fill. Must follow IC format.")]
            [StringLength(100)]
            public string user_IC { get; set; }
            public string user_matric { get; set; }
            public string user_name { get; set; }
            public string user_contact { get; set; }
            public string user_address { get; set; }
            public string CourseId { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> CourseList { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Lecturer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Comittee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();
            }

            Input = new InputModel();
            PopulateRoles();
            PopulateCourses();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.user_IC = Input.user_IC;
                user.user_matric = Input.user_matric;
                user.user_name = Input.user_name;
                user.user_contact = Input.user_contact;
                user.user_address = Input.user_address;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!String.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Student);
                    }

                    var userRoles = await _userManager.GetRolesAsync(user);
                    string userRole = userRoles.FirstOrDefault();
                    if (User.IsInRole(SD.Role_Admin))
                    {
                        TempData["success"] = "New User Created Successfully";
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }

                    if (userRoles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (userRoles.Contains("Lecturer"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (userRoles.Contains("Comittee"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (userRoles.Contains("Student"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Student" });
                    }
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            Input = new InputModel();
            PopulateRoles();
            PopulateCourses();
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        private void PopulateRoles()
        {
            Input.RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
        }
        private void PopulateCourses()
        {
            Input.CourseList = _context.Courses.Select(c => new SelectListItem
            {
                Value = c.course_ID.ToString(),
                Text = c.course_desc
            }).ToList();
        }
    }
}
using BlazorServerInvoice.BAL;
using BlazorServerInvoice.Data;
using Invoice.Models;
using Invoice.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerInvoice.Pages
{
    public partial class Register
    {
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly UserManager<AppUser> _userManager;
        //private readonly AppDbContext _context;

        private readonly SignInManager<IdentityUser> _signInManager;
        private static AppUser appUser { get;set; }
        public Register(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }


        //public Register(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _context = context;
        //}
       

        public async Task  UserRegisteration()
        {
            try
            {
                appUser.UserName = appUser.Email;
                //var result = await _userManager.CreateAsync(appUser, appUser.Password);
                //if (result.Succeeded)
                //{
                //    var result2 = await _userManager.AddToRoleAsync(appUser, "Admin");
                //    await _signInManager.SignInAsync(appUser, isPersistent: false).ConfigureAwait(false);
                //    //    return RedirectToAction("Index", "Home", new { Areas = "Admin" });
                //}
                //else
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        //         ModelState.AddModelError(string.Empty, error.Description);
                //    }
                //}

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            
        }

        protected override void OnInitialized()
        {

        }
    }
}

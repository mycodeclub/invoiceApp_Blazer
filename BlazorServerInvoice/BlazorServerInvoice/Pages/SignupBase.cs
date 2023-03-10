using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorServerInvoice.Pages
{
    public class SignupBase : ComponentBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        //public SignupBase(SignInManager<IdentityUser> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

    }
}

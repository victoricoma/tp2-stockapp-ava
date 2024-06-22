using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Identity
{
    public class AuthenticateService : IAutheticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email=email,
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return result.Succeeded;
        }
        //teste de atribuição de claims a um usuário
        //public async Task AplicarRoleAdmin (string email)
        //{
        //    var usuario = await _userManager.FindByEmailAsync(email);
        //    await _userManager.AddClaimAsync(usuario, new Claim("Admin", "true"));
        //}
        //public async Task RemoverRoleAdmin(string email)
        //{
        //    var usuario = await _userManager.FindByEmailAsync(email);
        //    await _userManager.RemoveClaimAsync(usuario, new Claim("Admin", "true"));
        //}

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

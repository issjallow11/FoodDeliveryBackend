using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Data.Services
{
    public interface IAuthenticateService
    {
        string Authenticate(AuthUser user);
        int GetCurrentUserId(ClaimsPrincipal principal);
        void Register(User user);
    }
}

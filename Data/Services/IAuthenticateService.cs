using FoodDeliveryBackend.Data.ViewModels;
using FoodDeliveryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Data.Services
{
    public interface IAuthenticateService
    {
        string Authenticate(AuthUser user);
        void Register(User user);
    }
}

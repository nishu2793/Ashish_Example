using MauimyApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApiIntegration.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string userName, string password);
    }
}

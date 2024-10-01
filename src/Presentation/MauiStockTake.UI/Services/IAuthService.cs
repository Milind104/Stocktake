using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiStockTake.UI.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiStockTake.UI.Services
{
    public class MockAuthService : IAuthService
    {
        public Task<bool> LoginAsync() => Task.FromResult(true);
    }
}

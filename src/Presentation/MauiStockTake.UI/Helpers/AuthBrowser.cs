using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Authentication;

namespace MauiStockTake.UI.Helpers
{
    public class AuthBrowser : IdentityModel.OidcClient.Browser.IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
#if WINDOWS
            var winUIResult = await WinUIEx.WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(Constants.RedirectUri));
            var authResult = ConvertToMauiWebAuthenticatorResult(winUIResult);
#else
            var authResult = await WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(Constants.RedirectUri));
#endif
            return new BrowserResult()
            {
                Response = ParseAuthenticationResult(authResult)
            };
        }

        private string ParseAuthenticationResult(WebAuthenticatorResult result)
        {
            string code = result?.Properties["code"];
            string scope = result?.Properties["scope"];
            string state = result?.Properties["state"];
            string sessionState = result?.Properties["session_state"];
            return $"{Constants.RedirectUri}#code={code}&scope={scope}&state={state}&session_state={sessionState}";
        }

#if WINDOWS
        private WebAuthenticatorResult ConvertToMauiWebAuthenticatorResult(WinUIEx.WebAuthenticatorResult winUIResult)
        {
            var properties = new Dictionary<string, string>
            {
                { "code", winUIResult.Properties["code"] },
                { "scope", winUIResult.Properties["scope"] },
                { "state", winUIResult.Properties["state"] },
                { "session_state", winUIResult.Properties["session_state"] }
            };

            return new WebAuthenticatorResult(properties);
        }
#endif

    }
}

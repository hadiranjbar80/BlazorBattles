using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattles.Client
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());
            if (await _localStorage.GetItemAsync<bool>("isAuthenticated"))
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,"Hadi")
                }, "Test authentication type");

                var user = new ClaimsPrincipal(identity);
                state = new AuthenticationState(user);
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using BlazingPizza.Shared;
using System.Net.Http.Json;

namespace BlazingPizza.Client.Services
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public ServerAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            /*
             //para probar
            var _claim = new Claim(ClaimTypes.Name, "Usuario Falso");
            var _identity = new ClaimsIdentity(new[] { _claim }, "serverauth");
            */

            var _userInfo = await _httpClient.GetFromJsonAsync<UserInfo>("user");

            var _identity = _userInfo.IsAuthenticated
                ? new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name,_userInfo.Name)}, "serverauth")
                : new ClaimsIdentity();
            
            return new AuthenticationState(new ClaimsPrincipal(_identity));
        }
    }
}

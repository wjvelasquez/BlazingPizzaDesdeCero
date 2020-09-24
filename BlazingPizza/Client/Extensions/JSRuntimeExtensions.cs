using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlazingPizza.Client.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jSRuntime, string message)
        {
            return jSRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}

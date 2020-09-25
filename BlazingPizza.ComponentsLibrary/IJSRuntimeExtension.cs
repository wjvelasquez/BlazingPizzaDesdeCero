using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary
{
    public static class IJSRuntimeExtension
    {
        public static async Task EvalVoidAsync(this IJSRuntime jsRuntime, string script)
        {
            if (script.Length > 0)
            {
                await jsRuntime.InvokeVoidAsync("eval", script);
            }
        }

        public static async Task<T> EvalAsync<T>(this IJSRuntime jsRuntime, string script)
        {
            T result = default;
            if (script.Length > 0)
            {
                script = $"(function() {{{script}}})()";
                result = await jsRuntime.InvokeAsync<T>("eval", script);
            }
            return result;
        }

        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }

        public static ValueTask<bool> Focus2(this IJSRuntime jsRuntime, string Id)
        {
            //                                        focus2
            return jsRuntime.InvokeAsync<bool>("focus2", Id);
        }

  
        public static ValueTask<T> GetAsync<T>(IJSRuntime jSRuntime, string key) =>
            jSRuntime.InvokeAsync<T>("blazorJSFunctions.getLocalStorage", key);

        public static ValueTask SetAsync(
            IJSRuntime jSRuntime, string key, object value) =>
            jSRuntime.InvokeVoidAsync("blazorJSFunctions.setLocalStorage", key, value);

        public static ValueTask DeleteAsync(IJSRuntime jSRuntime, string key) =>
            jSRuntime.InvokeVoidAsync("blazorJSFunctions.deleteLocalStorage", key);
    }
}

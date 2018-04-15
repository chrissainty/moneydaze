using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;

namespace MoneyDaze.Infrastructure.LocalStorage
{
    public static class BlazoredLocalStorage
    {
        public static string SAVE = "blzrdJsSaveToLocalStorage";
        public static string GET = "blzrdJsGetFromLocalStorage";
        public static string REMOVE = "blzrdJsRemoveFromLocalStorage";

        public static void Save(string identifier, object data)
        {
            var serialisedData = JsonUtil.Serialize(data);
            RegisteredFunction.Invoke<bool>(SAVE, identifier, serialisedData);
        }

        public static T Get<T>(string identifier)
        {
            var serialisedData = RegisteredFunction.Invoke<string>(GET, identifier);

            Console.WriteLine("Data From LocalStorage: " + serialisedData);
            if (serialisedData == null)
                return default(T);

            Console.WriteLine("Returning not null data from LS");
            return JsonUtil.Deserialize<T>(serialisedData);
        }

        public static void Remove(string identifier)
        {
            RegisteredFunction.Invoke<string>(REMOVE, identifier);
        }
    }
}

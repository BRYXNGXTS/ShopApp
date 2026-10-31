using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ShopApp.Services
{
    public class Navegacionservice : INavegacionService
    {
        public Task GoToAsync(string uri)
        {
            return Shell.Current.GoToAsync(uri);
        }

        public Task GoToAsync(string uri, IDictionary<string, object> parameters)
        {
            return Shell.Current.GoToAsync(uri, parameters);
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using ShopApp.DataAcces;

namespace ShopApp.ViewModels
{
    public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
    {
        [ObservableProperty]
        private int clienteId;

        [ObservableProperty]
        private ObservableCollection<Compra> compras = new ObservableCollection<Compra>();

        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private Product productoSeleccionado;

        [ObservableProperty]
        private int cantidad;

        public ICommand AddCommand { get; set; }

        public HelpSupportDetailViewModel()
        {
            var database = new ShopDbContext();
            Products = new ObservableCollection<Product>(database.Products);

            AddCommand = new MiComando(() =>
            {
                if (ProductoSeleccionado != null)
                {
                    var compra = new Compra(ClienteId, ProductoSeleccionado.Id, Cantidad);
                    Compras.Add(compra);
                }
            },
            () => true);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id"))
            {
                var idParam = int.Parse(query["id"].ToString());
                ClienteId = idParam;
            }
        }
    }
}
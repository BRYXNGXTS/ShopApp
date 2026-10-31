using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using ShopApp.DataAcces;
using ShopApp.Services;

namespace ShopApp.ViewModels
{
    public partial class HelpSupportViewModel : ViewModelGlobal
    {
        private readonly INavegacionService _navegacionService;

        [ObservableProperty]
        private int visitasPendientes;

        [ObservableProperty]
        private ObservableCollection<Client> clients;

        [ObservableProperty]
        private Client clienteSeleccionado;

        public HelpSupportViewModel(INavegacionService navegacionService)
        {
            var database = new ShopDbContext();
            Clients = new ObservableCollection<Client>(database.Clients);
            PropertyChanged += HelpSupportData_PropertyChanged;

            _navegacionService = navegacionService;
        }

        private async void HelpSupportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClienteSeleccionado) && ClienteSeleccionado != null)
            {
                var uri = $"{nameof(Views.HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
                await _navegacionService.GoToAsync(uri);
            }
        }
    }
}
using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();

        var dbcontext = new ShopDbContext();

        foreach (var clients in dbcontext.Clients)
        {
            container.Children.Add(new Label { Text = clients.Nombre });
        }
    }
}
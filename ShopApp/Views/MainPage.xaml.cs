using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopDbContext();
            category.Text = dbContext.Categories.Count().ToString();
            product.Text = dbContext.Products.Count().ToString();
            client.Text = dbContext.Clients.Count().ToString();

            int searchById = 1;

            var nombreProducto = dbContext.Products.FirstOrDefault(p => p.Id == searchById);
            if (nombreProducto != null)
            {
                product.Text = nombreProducto.Nombre;
            }
        }
    }
}
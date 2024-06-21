using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json; 

namespace ProductApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        public async Task OnGet()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync("https://localhost:5001/api/Product");
                    Products = JsonSerializer.Deserialize<List<Product>>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true 
                    });
                }
            }
            catch (Exception ex)
            {
                Products = new List<Product>(); 
            }
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }

}

using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            GenerateRandomProducts(10); // Gera 10 produtos aleatórios
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        private void GenerateRandomProducts(int numberOfProducts)
        {
            if (products.Count < numberOfProducts)
            {
                Random random = new Random();

                for (int i = products.Count + 1; i <= numberOfProducts; i++)
                {
                    string[] names = { "Camiseta", "Calça", "Boné", "Tênis", "Mochila", "Relógio", "Jaqueta", "Shorts", "Óculos", "Sapato" };
                    string[] adjectives = { "Confortável", "Elegante", "Esportivo", "Moderno", "Clássico", "Colorido", "Versátil", "Chique", "Descolado", "Estiloso" };

                    string name = $"{GetRandomElement(names)} {GetRandomElement(adjectives)}";
                    string description = GenerateRandomDescription(name); // Gerar descrição aleatória com base no nome
                    decimal price = Math.Round((decimal)(random.NextDouble() * 100 + 50), 2); 
                    string imageUrl = GetImageUrl(name); 

                    Product product = new Product
                    {
                        Id = i,
                        Name = name,
                        Description = description,
                        Price = price,
                        ImageUrl = imageUrl
                    };

                    products.Add(product);
                }
            }
        }

        private string GenerateRandomDescription(string productName)
        {
            Random random = new Random();
            string[] beginnings = { "O produto", "Este item", "Essa peça", "O novo", "O acessório" };
            string[] middles = { "é perfeito para", "combina com qualquer", "é essencial para", "vai deixar ", "é ideal para" };
            string[] endings = { "estilo moderno.", "visual elegante.", "aparência descolada.", "qualquer ocasião.", "um dia a dia confortável." };

            string beginning = GetRandomElement(beginnings);
            string middle = GetRandomElement(middles);
            string ending = GetRandomElement(endings);

            return $"{beginning} {productName} {middle} {ending}";
        }

        private string GetImageUrl(string productName)
        {
            string firstWord = productName.Split(' ')[0];

            // Gerar um número aleatório entre 1 e 10
            Random random = new Random();
            int randomNumber = random.Next(1, 11);

            // Adicionar aleatoriamente os números 2 e 3
            if (randomNumber <= 3)
            {
                firstWord += "2";
            }
            else if (randomNumber >= 8)
            {
                firstWord += "3";
            }

            // Tentar primeiro com extensão PNG
            string url = $"https://localhost:5001/images/{firstWord}.png";

            if (UrlExists(url))
            {
                return url;
            }

            // Se não existir, tentar com extensão JPG
            url = $"https://localhost:5001/images/{firstWord}.jpg";

            if (UrlExists(url))
            {
                return url;
            }

            return "";
        }

        private bool UrlExists(string url)
        {
            try
            {
                // Cria uma requisição HTTP para verificar se a URL existe
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        private string GetRandomElement(string[] array)
        {
            Random random = new Random();
            int index = random.Next(array.Length);
            return array[index];
        }
    }
}

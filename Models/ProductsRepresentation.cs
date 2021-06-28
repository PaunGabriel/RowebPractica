using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Domain;

namespace WebApplication1.Models
{
    public class ProductsRepresentation
    {
        public ProductsRepresentation(List<Product> products)
        {
            this.Products = products.Select(x => new ProductRepresentation(x.ProductID, x.Name, x.Price, x.BasePrice, x.CategoryID)).ToList();
        }

        [JsonProperty(PropertyName = "products")]
        public List<ProductRepresentation> Products { get; set; }
    }
}

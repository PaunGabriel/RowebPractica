using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(int productID, string name, decimal price, decimal basePrice, int categoryID)
        {
            this.ProductId = productID;
            this.Name = name;
            this.Price = price;
            this.BasePrice = basePrice;
            this.CategoryId = categoryID;
        }
        [JsonProperty(PropertyName = "productId")]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "basePrice")]
        public decimal BasePrice { get; set; }
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }
    }
}

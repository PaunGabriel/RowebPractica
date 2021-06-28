using System.Collections.Generic;
using System.Linq;
using WebApplication1.Business;
using WebApplication1.Domain;

namespace WebApplication1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }
        public void Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
        public Product GetById(int Id)
        {
            return _context.Products.Where(x => x.ProductID == Id).FirstOrDefault();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
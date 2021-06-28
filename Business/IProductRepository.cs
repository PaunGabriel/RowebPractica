using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Business
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product Insert(Product product);
        void Delete(Product product);
        Product GetById(int Id);
        void Update(Product product);

    }
}
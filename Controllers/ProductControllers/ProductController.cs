using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.ProductControllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("api/product")]
        public ProductsRepresentation GetAll()
        {
            var dbProducts = _repo.GetProducts();
            return new ProductsRepresentation(dbProducts);
        }
        [HttpPost]
        [Route("api/product")]
        public async Task<Object> AddProduct([FromBody] Product product)
        {
            try
            {
                _repo.Insert(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpDelete]
        [Route("api/product")]
        public bool DeleteProduct(Product product)
        {
            try
            {
                _repo.Delete(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut]
        [Route("api/product")]
        public bool UpdateProduct(Product product)
        {
            try
            {
                _repo.Update(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public Object GetAllProductsById(int id)
        {
            var data = _repo.GetById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [HttpPost]
        [Route("api/product/image/{id}")]
        public void UploadImage([FromRoute] int id, [FromForm] IFormFile file)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Uploads\Images", file.FileName);
            var streamImage = new FileStream(path, FileMode.Create);
            file.CopyTo(streamImage);
            var product = _repo.GetById(id);
            product.Image = file.FileName;
            _repo.Update(product);
        }
        [HttpGet]
        [Route("api/product/{id}/image/")]
        public IActionResult getImage(int id)
        {
            string fileName;
            var product = _repo.GetById(id);
            fileName = product.Image;
            string path = Path.Combine(Environment.CurrentDirectory, @"Uploads\Images", fileName);
            string mimeType = MimeMapping.MimeUtility.GetMimeMapping(fileName);
            var image = System.IO.File.OpenRead(path);
            return File(image, mimeType);
        }

    }
}


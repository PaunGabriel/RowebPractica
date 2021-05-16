using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Models;
using WebApplication1.Domain;

namespace WebApplication1.Controllers.CategoryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public CategoriesRepresentation GetAll()
        {
            var dbCategories = _repo.GetCategories();
            return new CategoriesRepresentation(dbCategories);
        }
        [HttpPost]
        public CategoryRepresentation PostCategory(Category category)
        {
            var dbCategories = _repo.Insert(category);
            return new CategoryRepresentation(dbCategories.CategoryID,dbCategories.Name);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _repo.GetCategoryByID(id);
            if(category != null)
            {
                _repo.Delete(category);
                return Ok();
            }
            return NotFound("Id not found");
        }
        [HttpPut]
        public CategoryRepresentation UpdateCategory(Category category)
        {
            var dbCategories = _repo.Update(category);
            return new CategoryRepresentation(dbCategories.CategoryID, dbCategories.Name);
        }
    }
}

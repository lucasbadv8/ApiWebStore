using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
        [HttpPost]
        [Route("v1/products")]
        [AllowAnonymous]
        public IActionResult Post()
        {
            var produto = new Product("Titulo qlqr",123,"Image blaus",5);
            _repository.Save(produto);
            return Ok(_repository.ProductExists(produto.Title));
        }
    }
}

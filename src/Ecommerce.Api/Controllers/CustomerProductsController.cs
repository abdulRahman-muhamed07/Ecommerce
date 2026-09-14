using Ecommerce.Application.Features.Catalog.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductsController : ControllerBase
    {


        private readonly GetProductsHandler _handler;


        public CustomerProductsController(GetProductsHandler handler)
        {
            _handler = handler;
        }











    }
}

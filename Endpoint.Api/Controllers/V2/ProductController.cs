using AutoMapper;
using Endpoint.Api.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers.V2
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductController : Api.Controllers.V1.ProductController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
        public override async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            return new ProductViewModel();
        }
    }
}

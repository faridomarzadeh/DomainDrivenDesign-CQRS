using AutoMapper;
using Clean_arch.Application.Products.Create;
using Clean_arch.Application.Products.Delete;
using Clean_arch.Application.Products.Edit;
using Clean_arch.Query.Models.Products;
using Clean_arch.Query.Products.GetById;
using Clean_arch.Query.Products.GetList;
using Endpoint.Api.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public virtual async Task<List<ProductViewModel>> GetProducts()
        {
            var results = await _mediator.Send(new GetProductListQuery());
            return _mapper.Map<List<ProductViewModel>>(results).AddLinks();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            if (result == null)
                return NotFound("Product not found");
            return _mapper.Map<ProductViewModel>(result).AddLinks();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            var url = Url.Action(nameof(GetProductById), "product", new { id = result }, Request.Scheme);
            return Created(url, result);
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}

using Clean_arch.Infrastructure.Persistant.Ef;
using Clean_arch.Query.Models.Products;
using Clean_arch.Query.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_arch.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadModel>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productReadRepository.GetById(request.ProductId);
        }
    }
}
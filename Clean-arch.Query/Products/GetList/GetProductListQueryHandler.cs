using Clean_arch.Infrastructure.Persistant.Ef;
using Clean_arch.Query.Models.Products;
using Clean_arch.Query.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_arch.Query.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductReadModel>>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductListQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<ProductReadModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productReadRepository.GetAll();
        }
    }
}
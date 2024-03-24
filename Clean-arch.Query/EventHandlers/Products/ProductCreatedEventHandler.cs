using Clean_arch.Domain.ProductAgg.Events;
using Clean_arch.Domain.Products;
using Clean_arch.Query.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.EventHandlers.Products
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductRepository _writeRepository;
        public ProductCreatedEventHandler(IProductReadRepository productReadRepository, IProductRepository productRepository)
        {
            _readRepository = productReadRepository;
            _writeRepository = productRepository;
        }
        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.Id);
            await _readRepository.Insert(new ProductReadModel()
            {
                Id = notification.Id,
                CreationDate = notification.CreationDate,
                Description = product.Description,
                Images = null,
                Money = product.Money,
                Title = product.Title
            });
        }
    }
}

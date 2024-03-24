using Clean_arch.Domain.ProductAgg.Events;
using Clean_arch.Domain.Products;
using Clean_arch.Query.Models.Products;
using MediatR;

namespace Clean_arch.Query.EventHandlers.Products
{
    public class ProductEditedEventHandler : INotificationHandler<ProductEdited>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductRepository _writeRepository;
        public ProductEditedEventHandler(IProductReadRepository productReadRepository, IProductRepository productRepository)
        {
            _readRepository = productReadRepository;
            _writeRepository = productRepository;
        }
        public async Task Handle(ProductEdited notification, CancellationToken cancellationToken)
        {
            var product = await _writeRepository.GetById(notification.ProductId);
            await _readRepository.Update(new ProductReadModel()
            {
                Id = product.Id,
                CreationDate = notification.CreationDate,
                Description = product.Description,
                Images = product.Images,
                Money = product.Money,
                Title = product.Title
            });
        }
    }
}

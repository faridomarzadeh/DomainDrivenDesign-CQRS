using Clean_arch.Domain.ProductAgg.Events;
using Clean_arch.Query.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.EventHandlers.Products
{
    public class ProductRemovedEventHandler : INotificationHandler<ProductRemoved>
    {
        private readonly IProductReadRepository _readRepository;
        public ProductRemovedEventHandler(IProductReadRepository productReadRepository)
        {
            _readRepository = productReadRepository;
        }
        public async Task Handle(ProductRemoved notification, CancellationToken cancellationToken)
        {
            await _readRepository.Delete(notification.Id);
        }
    }
}

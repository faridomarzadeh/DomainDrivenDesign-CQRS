using Clean_arch.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Application.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMediator mediator)
        {
            _mediator = mediator;
            _repository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            _repository.Remove(product);
            product.RemoveProduct();
            foreach (var @event in product.DomainEvents)
            {
                _mediator.Publish(@event);
            }
            return await Unit.Task;
        }
    }
}

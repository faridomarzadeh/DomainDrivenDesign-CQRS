using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Application.Products.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public long Id { get; private set; }
        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}

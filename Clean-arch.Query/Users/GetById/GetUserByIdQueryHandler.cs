using Clean_arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Users.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserReadModel>
    {
        private readonly IUserReadRepository _readRepository;
        public GetUserByIdQueryHandler(IUserReadRepository userReadRepository)
        {
            _readRepository = userReadRepository;
        }
        public async Task<UserReadModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetById(request.Id);
        }
    }
}

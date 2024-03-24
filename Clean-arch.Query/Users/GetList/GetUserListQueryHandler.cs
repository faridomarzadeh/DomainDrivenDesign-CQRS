using Clean_arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Users.GetList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserReadModel>>
    {
        private readonly IUserReadRepository _readRepository;
        public GetUserListQueryHandler(IUserReadRepository userReadRepository)
        {
            _readRepository = userReadRepository;
        }
        public async Task<List<UserReadModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAll();
        }
    }
}

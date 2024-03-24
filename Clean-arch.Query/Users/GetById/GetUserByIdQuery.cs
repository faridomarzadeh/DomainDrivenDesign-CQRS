using Amazon.Runtime.Internal;
using Clean_arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Users.GetById
{
    public record GetUserByIdQuery(long Id): IRequest<UserReadModel>
    {
    }
}

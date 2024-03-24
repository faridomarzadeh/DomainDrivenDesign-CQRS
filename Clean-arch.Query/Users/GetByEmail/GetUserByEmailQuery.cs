﻿using Clean_arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Users.GetByEmail
{
    public record GetUserByEmailQuery(string email) : IRequest<UserReadModel> { }
}

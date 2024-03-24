using Clean_arch.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Application.Users.Register
{
    public class RegisterUserCommand:IRequest<long>
    {
        public string Email { get;  set; }
        public PhoneNumber PhoneNumber { get; set; }

    }
}

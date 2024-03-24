using Clean_arch.Domain.UserAgg;
using Clean_arch.Domain.UserAgg.Events;
using Clean_arch.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, long>
    {
        private readonly IUserRepository _writeRepository;
        private readonly IMediator _mediator;
        public RegisterUserCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _writeRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<long> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registeredUser = User.Register(request.Email, request.PhoneNumber);
            _writeRepository.Add(registeredUser);
            await _writeRepository.SaveChange();
            await _mediator.Publish(new UserRegistered(registeredUser.Id, registeredUser.Email));
            return registeredUser.Id;
        }
    }
}

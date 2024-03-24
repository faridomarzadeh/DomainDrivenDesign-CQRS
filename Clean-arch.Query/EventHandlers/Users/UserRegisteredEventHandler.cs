using Clean_arch.Domain.UserAgg;
using Clean_arch.Domain.UserAgg.Events;
using Clean_arch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.EventHandlers.Users
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegistered>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserRepository _userWriteRepository;
        public UserRegisteredEventHandler(IUserReadRepository userReadRepository, IUserRepository userRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userRepository;
        }
        public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
        {
            var user =await _userWriteRepository.GetById(notification.UserId);
            await _userReadRepository.Insert(new UserReadModel()
            {
                CreationDate = notification.CreationDate,
                Email = notification.Email,
                Family = user.Family,
                Id = notification.UserId,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
            });

        }
    }
}

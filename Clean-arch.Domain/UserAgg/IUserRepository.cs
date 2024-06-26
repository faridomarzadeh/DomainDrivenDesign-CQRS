﻿using Clean_arch.Domain.Users;

namespace Clean_arch.Domain.UserAgg
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<User> GetById(long id);
        Task SaveChange();
        void Update(User user);

    }
}

using Clean_arch.Query.Models.Users;
using Clean_arch.Query.Shared.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Repositories
{
    public class UserReadRepository : IBaseReadRepository<UserReadModel>, IUserReadRepository
    {
        private readonly IMongoCollection<UserReadModel> _collection;
        public UserReadRepository(IMongoClient client)
        {
            var db = client.GetDatabase("Clean_Arch");
            _collection = db.GetCollection<UserReadModel>(typeof(UserReadModel).Name);
        }
        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(u=>u.Id == id);
        }

        public async Task<List<UserReadModel>> GetAll()
        {
            var result = await _collection.FindAsync(u => true);
            return result.ToList();
        }

        public async Task<UserReadModel> GetByEmail(string email)
        {
            var result = await _collection.FindAsync(p=>p.Email == email);
            return result.FirstOrDefault();
        }

        public async Task<UserReadModel> GetById(long id)
        {
            var result = await _collection.FindAsync(u=>u.Id==id);
            return result.FirstOrDefault();
        }

        public async Task Insert(UserReadModel entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(UserReadModel entity)
        {
            await _collection.ReplaceOneAsync(f => f.Id == entity.Id, entity);
        }
    }
}

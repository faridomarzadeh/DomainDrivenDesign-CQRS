using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Shared.Repository
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : BaseReadModel
    {
        private readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoClient client)
        {
            var db = client.GetDatabase("Clean_Arch");
            _collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(p=>p.Id == id);
        }
        public async Task<List<TEntity>> GetAll()
        {
            var results = await _collection.FindAsync<TEntity>(p => true);
            return results.ToList();
        }

        public async Task<TEntity> GetById(long id)
        {
            var result = await _collection.FindAsync(p => p.Id == id);
            return result.FirstOrDefault();
        }

        public async Task Insert(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _collection.ReplaceOneAsync(p=> p.Id == entity.Id, entity);
        }
    }
}

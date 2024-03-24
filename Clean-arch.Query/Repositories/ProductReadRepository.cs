using Clean_arch.Query.Models.Products;
using Clean_arch.Query.Shared.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_arch.Query.Repositories
{
    public class ProductReadRepository : IBaseReadRepository<ProductReadModel>, IProductReadRepository
    {
        private readonly IMongoCollection<ProductReadModel> _collection;
        public ProductReadRepository(IMongoClient client)
        {
            var db = client.GetDatabase("Clean_Arch");
            _collection = db.GetCollection<ProductReadModel>(typeof(ProductReadModel).Name);
        }
        public async Task Delete(long id)
        {
            await _collection.DeleteOneAsync(d=>d.Id == id);
        }

        public async Task<List<ProductReadModel>> GetAll()
        {
            var result = await _collection.FindAsync(p => true);
            return result.ToList();
        }

        public async Task<ProductReadModel> GetById(long id)
        {
            var result = await _collection.FindAsync(p =>p.Id==id);
            return result.FirstOrDefault();
        }

        public async Task Insert(ProductReadModel entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(ProductReadModel entity)
        {
            await _collection.ReplaceOneAsync(p => p.Id == entity.Id, entity);
        }
    }
}

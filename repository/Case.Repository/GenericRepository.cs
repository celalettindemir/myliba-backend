using System.Linq.Expressions;
using Case.Database;
using Case.Domain.Entity.Base;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Case.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> Collection;

    public GenericRepository(IMongoClient mongoClient,IOptions<MongoDbSettings> options)
    {
        var db = mongoClient.GetDatabase(options.Value.Database);
        this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null
            ? Collection.AsQueryable()
            : Collection.AsQueryable().Where(predicate);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return Collection.Find(predicate).FirstOrDefaultAsync();
    }

    public Task<T> GetByIdAsync(string id)
    {
        return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        var options = new InsertOneOptions { BypassDocumentValidation = false };
        await Collection.InsertOneAsync(entity, options);
        return entity;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
        return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
    }

    public async Task<T> UpdateAsync(string id, T entity)
    {
        return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
    }

    public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
    {
        return await Collection.FindOneAndReplaceAsync(predicate, entity);
    }

    public async Task<T> DeleteAsync(T entity)
    {
        return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
    }

    public async Task<T> DeleteAsync(string id)
    {
        return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
    }

    public async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
    {
        return await Collection.FindOneAndDeleteAsync(filter);
    }
}


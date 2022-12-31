using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Case.Domain.Entity.Base;

[Serializable]
[BsonIgnoreExtraElements(Inherited = true)]
public abstract class BaseEntity
{
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    [BsonElement(Order = 0)]
    public virtual string Id { get; } = ObjectId.GenerateNewId().ToString();

    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement(Order = 101)]
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement(Order = 101)]
    public virtual DateTime UpdatedAt { get; set; }
    
    [BsonElement("IsDeleted")]
    public virtual bool IsDeleted { get; set; } = false;
}
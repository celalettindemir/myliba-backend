using System.ComponentModel.DataAnnotations;
using Case.Domain.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace Case.Domain.Entity;

public class Personal:BaseEntity
{
    [BsonElement("name")]
    [Required]
    public string Name { get; set; }

    [BsonElement("surname")]
    [Required]
    public string Surname { get; set; }

    [BsonElement("email")]
    [Required]
    public string Email { get; set; }

}
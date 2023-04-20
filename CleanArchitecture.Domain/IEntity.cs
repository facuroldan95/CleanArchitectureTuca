using MongoDB.Bson.Serialization.Attributes;

namespace CleanArchitecture.Domain
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        string? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}

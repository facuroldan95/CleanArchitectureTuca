using CleanArchitecture.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanArchitecture.Domain
{
    public class Streamer : IEntity
    {
        public string? Nombre { get; set; }

        public string? Url { get; set; }

        public ICollection<Video>? Videos { get; set; }
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}

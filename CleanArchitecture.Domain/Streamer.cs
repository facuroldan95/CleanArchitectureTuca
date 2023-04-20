using CleanArchitecture.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanArchitecture.Domain
{
    public class Streamer : EntityBase
    {
        public string? Nombre { get; set; }

        public string? Url { get; set; }

        public ICollection<Video>? Videos { get; set; }

    }
}

using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video : IEntity
    {
        public Video() 
        {
            Actores = new HashSet<Actor>();
        }
        //implementar la interfaz IEntity
        public string Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

        public string? Nombre { get; set; }

        public int StreamerId { get; set; }

       public virtual Streamer? Streamer { get; set; }

        public virtual ICollection<Actor> Actores { get; set; }

        public virtual Director Director { get; set; }

    }
}

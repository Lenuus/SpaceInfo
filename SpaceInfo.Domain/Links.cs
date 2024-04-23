using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class Links : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public Guid Id { get; set; }
        public string NearEarthObjectId { get; set; }
        public NearEarthObject NearEarthObject { get; set; }
        public string? Previous { get; set; }
        public string? Next { get; set; }
        public string? Self { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class Diameter : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public Guid Id { get; set; }
        public string NearEarthObjectId { get; set; }
        public Kilometers Kilometers { get; set; }
        public Meters Meters { get; set; }
        public Miles Miles { get; set; }
        public Feet Feet { get; set; }
        public NearEarthObject NearEarthObject { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

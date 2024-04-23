using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class NearEarthObject : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public string Id { get; set; }
        public Links Link { get; set; }
        public Diameter Diameter { get; set; }
        public string NeoReferenceId { get; set; }
        public string? Name { get; set; }
        public string? NasaJplUrl { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public bool IsPotentiallyHazardous { get; set; }
        public List<CloseApproachData> CloseApproachDatas { get; set; } = new List<CloseApproachData>();
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

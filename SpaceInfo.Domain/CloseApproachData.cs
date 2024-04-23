using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class CloseApproachData : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public Guid Id { get; set; }
        public string NearEarthObjectId { get; set; }
        public RelativeVelocity RelativeVelocity { get; set; }
        public MissDistance MissDistance { get; set; }
        public NearEarthObject NearEarthObject { get; set; }
        public string? CloseApproachDate { get; set; }
        public string? CloseApproachDateFull { get; set; }
        public double EpochDateCloseApproach { get; set; }
        public string? OrbitingBody { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

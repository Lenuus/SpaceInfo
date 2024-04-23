using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class RelativeVelocity : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public Guid Id { get; set; }
        public Guid CloseApproachDataId { get; set; }
        public CloseApproachData CloseApproachData { get; set; }
        public string? KilometersPerSecond { get; set; }
        public string? KilometersPerHour { get; set; }
        public string? MilesPerHour { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public class MissDistance : IBaseEntity, ISoftDeletable, ISoftCreatable, ISoftUpdatable
    {
        public Guid Id { get; set; }
        public Guid CloseApproachDataId { get; set; }
        public CloseApproachData CloseApproachData { get; set; }
        public string? Astronomical { get; set; }
        public string? Lunar { get; set; }
        public string? Kilometers { get; set; }
        public string? Miles { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

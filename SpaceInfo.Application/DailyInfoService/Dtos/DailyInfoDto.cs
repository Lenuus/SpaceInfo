using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Application.DailyInfoService.Dtos
{
    public class DailyInfoDto
    {
        public Guid Id { get; set; }
        public string? Copyright { get; set; }
        public DateTime Date { get; set; }
        public string? Explanation { get; set; }
        public string? Hdurl { get; set; }
        public string? MediaType { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

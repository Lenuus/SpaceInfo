using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfo.Domain
{
    public interface ISoftCreatable
    {
        public DateTime InsertedDate { get; set; }
    }
}

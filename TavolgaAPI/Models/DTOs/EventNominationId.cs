using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Models.DTOs
{
    public class EventNominationId
    {
        public int EventId { get; set; }
        public int NominationId { get; set; }
        public bool IsDeleteAction { get; set; }
    }
}

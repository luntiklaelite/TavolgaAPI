using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    public abstract class ValuatorBase:BaseUser
    {
        public virtual List<Nomination> Nominations { get; set; } = new List<Nomination>();
        public virtual List<Event> Events { get; set; } = new List<Event>();
    }
}

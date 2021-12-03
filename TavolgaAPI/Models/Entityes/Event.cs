using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models.Entityes
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Nomination> Nominations { get; set; } = new List<Nomination>();
        public List<ValuatorBase> ValuatorsEdited { get; set; } = new List<ValuatorBase>();
    }
}

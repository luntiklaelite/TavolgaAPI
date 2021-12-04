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
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public virtual List<Nomination> Nominations { get; set; } = new List<Nomination>();
        public virtual List<ValuatorBase> ValuatorsEdited { get; set; } = new List<ValuatorBase>();
    }
}

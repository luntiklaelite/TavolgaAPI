using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models.Entityes
{
    [Table("Nominations")]
    public class Nomination
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [Required]
        public virtual Event Event { get; set; }
        public virtual List<Criteria> Criteries { get; set; } = new List<Criteria>();
        public virtual List<ValuatorBase> Valuators { get; set; } = new List<ValuatorBase>();
    }
}

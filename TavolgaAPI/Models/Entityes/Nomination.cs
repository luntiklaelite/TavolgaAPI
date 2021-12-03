using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes
{
    [Table("Nominations")]
    public class Nomination
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
        public List<Criteria> Criteries { get; set; } = new List<Criteria>();
    }
}

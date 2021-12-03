using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TavolgaAPI.Models.Entityes
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Nomination> Nomination { get; set; } = new List<Nomination>();
    }
}

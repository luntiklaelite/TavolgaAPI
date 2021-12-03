using System.ComponentModel.DataAnnotations;

namespace TavolgaAPI.Models.Entityes
{
    public class Nomination
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}

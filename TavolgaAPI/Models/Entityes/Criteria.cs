using System.ComponentModel.DataAnnotations;

namespace TavolgaAPI.Models.Entityes
{
    public class Criteria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Nomination Nomination { get; set; }
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }

    }
}

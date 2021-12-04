using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TavolgaAPI.Models.Entityes
{
    [Table("Criterias")]
    public class Criteria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore,Required]
        public Nomination Nomination { get; set; }
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }

    }
}

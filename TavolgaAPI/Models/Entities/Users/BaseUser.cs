using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("BaseUser")]
    public class BaseUser
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public string FIO { get; set; }
        [Required, MaxLength(64)]
        public string Email { get; set; }
        [Required, MaxLength(32)]
        public string Password { get; set; }
    }
}

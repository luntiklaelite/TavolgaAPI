using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("BaseUsers")]
    public abstract class BaseUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }        
    }
}

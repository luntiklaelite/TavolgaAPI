using System.ComponentModel.DataAnnotations;

namespace TavolgaAPI.Models.Entityes.Users
{
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

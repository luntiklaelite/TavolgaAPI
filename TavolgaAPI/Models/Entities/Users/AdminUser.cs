using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("AdminUsers")]
    public class AdminUser:BaseUser
    {
        public override string Role => "Admin";
    }
}

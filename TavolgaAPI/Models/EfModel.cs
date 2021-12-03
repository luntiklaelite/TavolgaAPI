using Microsoft.EntityFrameworkCore;

namespace TavolgaAPI.Models
{
    public class EfModel:DbContext
    {
        public EfModel(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

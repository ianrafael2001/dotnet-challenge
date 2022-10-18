using desafio.Entity;

namespace desafio.Models
{
    public class UserModel
    {
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        
        public string? type { get; set; }
    }
}
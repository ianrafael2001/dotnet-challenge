using desafio.Models;

namespace desafio.Repository
{
    public static class UserRepository
    {
        public static UserModel Get(string username, string password){
            var users = new List<UserModel>();
            users.Add(new UserModel { id = 1, username = "admin", password= "admin", type="admin"});
            users.Add(new UserModel { id = 2, username = "user", password= "user", type="user"});

            return users.Where(x=> x.username == username && x.password == password ).FirstOrDefault();
        }
    }
}
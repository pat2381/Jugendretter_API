namespace Jugendretter_API.Models
{
    public class User
    {

        public int ID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Surename { get; set; }
        public string password { get; set; }

        public User()
        {
            
        }

    }
}

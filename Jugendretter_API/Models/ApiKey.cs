namespace Jugendretter_API.Models
{
    public class ApiKey
    {

        public int ID { get; set; }
        public string API_Key { get; set; }

        public User User { get; set; }
    }
}

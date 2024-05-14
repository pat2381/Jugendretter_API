using System;

namespace Jugendretter_API.Entities
{
    public class User
    {

        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Surename { get; set; }
        public string password { get; set; }


    }
}
